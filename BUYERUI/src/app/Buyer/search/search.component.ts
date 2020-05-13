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
  list1:Items[]=[];
  id: number;
  id2:number;
  constructor(private builder:FormBuilder,private service:ItemsService,private route:Router) {
 }

  ngOnInit() {
    this.itemform=this.builder.group({
      itemName:['']
    })
   
  }


  Search()
  {
    
    this.service.SearchItems(this.itemform.value['itemName']).subscribe(res=>
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
  AddtoCart(item2:Items){
    this.id=item2.itemId;
    this.service.GetCart(this.id).subscribe(res=>{this.id2=res,console.log(this.id2)
    if(this.id2!=0)
    {
      alert("already exists")
    }
    else{
    console.log(item2);
   this.cart=new Cart();
   this.cart.cartId=Math.floor(Math.random()*1000);
   this.cart.itemName=item2.itemName;
   this.cart.buyerId=Number(localStorage.getItem('Buyerid'));
   this.cart.stockno=item2.stockno;
   this.cart.price=item2.price;
   this.cart.itemId=item2.itemId;
   this.cart.description=item2.description;
   this.cart.remarks=item2.remarks;
   this.cart.imageName=item2.imageName
   console.log(this.cart);
   this.service.AddtoCart(this.cart).subscribe(res=>{
     console.log("Record added To Cart");
     alert('Added To Cart');
   })
  }
  })}
  Logout(){
    this.route.navigateByUrl('HOME');
  }
}
