namespace Logger.Factories
{
    using Layouts;
    using System;

    public static class LayoutFactory
    {
        public static ILayout CreateLayout(string type)
        {
            if (type == "SimpleLayout")
            {
                return new SimpleLayout();
            }
            else if (type == "XmlLayout")
            {
                return new XmlLayout();
            }
            else
            {
                throw new InvalidOperationException("Invalid type!");
            }
        }
    }
}
