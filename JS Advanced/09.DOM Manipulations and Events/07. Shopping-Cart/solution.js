function solve() {
   let textAreaElement = document.getElementsByTagName('textarea')[0];
   let checkoutElement = document.getElementsByClassName('checkout')[0];
   let addButtonElement = document.querySelectorAll('button[class="add-product"]');
   let products = [];
   let totalPrice = 0;

   let addProductToCart = function (e) {
      let productElement = e.currentTarget.parentElement.parentElement;
      let productName = productElement.querySelectorAll('.product-title')[0].textContent;
      let productPrice = productElement.querySelectorAll('.product-line-price')[0].textContent;
      //console.log(productName);
      //console.log(productPrice);

      if (!products.includes(productName)) {
         products.push(productName);
      }

      totalPrice += Number(productPrice);

      textAreaElement.textContent += `Added ${productName} for ${productPrice} to the cart.\n`;
   }

   for (let button of addButtonElement) {
      button.addEventListener('click', addProductToCart);
   }

   let checkoutCart = function (e) {
      textAreaElement.textContent += `You bought ${products.join(', ')} for ${totalPrice.toFixed(2)}.`;

      for (let button of addButtonElement) {
         button.disabled = true;
      }

      e.currentTarget.disabled = true;
   }

   checkoutElement.addEventListener('click', checkoutCart);
}