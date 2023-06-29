using System;
using Formula1.Utilities;
using Formula1.Repositories;
using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository formulaOneCarRepository;

        public Controller()
        {
            pilotRepository = new PilotRepository(); ;
            raceRepository = new RaceRepository(); ;
            formulaOneCarRepository = new FormulaOneCarRepository(); ;
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = pilotRepository.FindByName(pilotName);
            IFormulaOneCar formulaOneCar = formulaOneCarRepository.FindByName(carModel);

            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            if (formulaOneCar == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            pilot.AddCar(formulaOneCar);
            return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, formulaOneCar.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = raceRepository.FindByName(raceName);
            IPilot pilot = pilotRepository.FindByName(pilotFullName);

            if (race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (pilot == null || pilot.CanRace == false || race.Pilots.Any(p => p.FullName == pilotFullName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            race.AddPilot(pilot);
            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar car;

            if (type == "Ferrari")
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if (type == "Williams")
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type)); 
            }

            if (formulaOneCarRepository.FindByName(model) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            formulaOneCarRepository.Add(car);
            return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepository.FindByName(fullName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            pilotRepository.Add(new Pilot(fullName));
            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepository.FindByName(raceName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            raceRepository.Add(new Race(raceName, numberOfLaps));
            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string PilotReport()
        {
            List<IPilot> pilots = pilotRepository.Models.OrderByDescending(p => p.NumberOfWins).ToList();
            StringBuilder sb = new StringBuilder();

            foreach (var pilot in pilots)
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            List<IRace> races = raceRepository.Models.Where(r => r.TookPlace == true).ToList();
            StringBuilder sb = new StringBuilder();

            foreach (var race in races)
            {
                sb.AppendLine(race.RaceInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            var race = this.raceRepository.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (race.TookPlace == true)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            race.TookPlace = true;
            List<IPilot> ordered = race.Pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps)).Take(3).ToList();
            IPilot winnerPilot = ordered[0];
            winnerPilot.WinRace();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(OutputMessages.PilotFirstPlace,winnerPilot.FullName,raceName));
            sb.AppendLine(string.Format(OutputMessages.PilotSecondPlace, ordered[1].FullName, raceName));
            sb.AppendLine(string.Format(OutputMessages.PilotThirdPlace, ordered[2].FullName, raceName));

            return sb.ToString().TrimEnd();
        }
    }
}
