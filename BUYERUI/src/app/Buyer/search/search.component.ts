import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Items } from 'src/app/Models/items';
import { Cart } from 'src/app/Models/cart';
import { ItemsService } from 'src/app/services/items.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  itemform:FormGroup;
  submitted=false;
  list:Items[]=[];
  item:Items
  num:number;
  cart:Cart;
  constructor(private builder:FormBuilder,private service:ItemsService,private route:Router) {
 }

  ngOnInit() {
    this.itemform=this.builder.group({
      productName:['']
    })
   
  }


  Search()
  {
    
    this.service.SearchItems(this.itemform.value['productName']).subscribe(res=>
      {
        
       this.list=res;
        console.log(this.list);
      },
      err=>{
        console.log(err);
      }
      )
  }
  Buy(item:Items){
    console.log(item);
    localStorage.setItem('item',JSON.stringify(item));
    this.route.navigateByUrl('/buyer/buyitem');
  }
  AddtoCart(items:Items){
    console.log(items);
   this.cart=new Cart();
   this.cart.cartId=Math.round(Math.random()*1000);
   this.cart.itemName=items.productName;
   this.cart.buyerId=Number(localStorage.getItem('Buyerid'));
   this.cart.stockno=items.stockno;
   this.cart.price=items.price;
   this.cart.itemId=items.productId;
   this.cart.description=items.description;
   this.cart.remarks=items.remarks;
   this.cart.imageName=items.imageName;
   console.log(this.cart);
   this.service.AddToCart(this.cart).subscribe(res=>{
     console.log("Record added To Cart");
     alert('Added To Cart');
   })
  }
  Logout(){
    this.route.navigateByUrl('home');
  }
}
