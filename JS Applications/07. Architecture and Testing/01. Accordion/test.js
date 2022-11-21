const { chromium } = require('playwright-chromium');
const { expect } = require('chai');
//const { it } = require('node:test');

let browser, page; // Declare reusable variables

describe('E2E tests', async function() {
  this.timeout(5000);

  //before(async () => { browser = await chromium.launch({headless: false, slowMo: 500}); });
  before(async () => { browser = await chromium.launch(); });
  after(async () => { await browser.close(); });
  beforeEach(async () => { page = await browser.newPage(); });
  afterEach(async () => { await page.close(); }); 

   it('loads article titles', async() => {
     await page.goto('http://localhost:5500');
     
     await page.waitForSelector('.accordion div.head>span');
     const textContent = await page.textContent('#main');

     expect(textContent).to.contain('Scalable Vector Graphics');
     expect(textContent).to.contain('Open standard');
     expect(textContent).to.contain('Unix');
     expect(textContent).to.contain('ALGOL');
   });

   it('button “More” functionality', async() => {
     await page.goto('http://localhost:5500');

     await page.click('text=More');
     await page.waitForSelector('.extra p')

     const text = await page.textContent('.extra p');
     const visible = await page.isVisible('.extra p');

     expect(text).to.contain('Scalable Vector Graphics (SVG) is an Extensible Markup Language (XML)');
     expect(visible).to.be.true;
   });

   it('button “More” functionality', async() => {
    await page.goto('http://localhost:5500');

    await page.click('text=More');
    await page.waitForSelector('.extra p')
    
    let visible = await page.isVisible('.extra p');
    expect(visible).to.be.true;

    await page.click('text=Less');
    visible = await page.isVisible('.extra p');
    expect(visible).to.be.false;
  });
});
 