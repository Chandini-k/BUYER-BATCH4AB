import { Component, OnInit } from '@angular/core';
import { ItemsService } from 'src/app/services/items.service';
import { Router } from '@angular/router';
import { Items } from 'src/app/Models/items';
import { Cart } from 'src/app/Models/cart';

@Component({
  selector: 'app-viewcart',
  templateUrl: './viewcart.component.html',
  styleUrls: ['./viewcart.component.css']
})
export class ViewcartComponent implements OnInit {
  cartlist:Cart[];
  item:Items;
    constructor(private route:Router,private service:ItemsService) {
      let id=Number(localStorage.getItem('Buyerid'))
      this.service.GetCart(id).subscribe(res=>{
        this.cartlist=res;
        console.log(this.cartlist);
      })
     }
    ngOnInit() {
    }
  BuyNow(item1:Items){
        console.log(item1);
        this.item=item1;
        localStorage.setItem("item1",JSON.stringify(this.item));
        this.route.navigateByUrl('/buyer/buyitem');
  }
  Remove(itemId:number)
  {
    console.log(itemId);
    let id=itemId;
    this.service.DeleteCart(id).subscribe(res=>{
      console.log('Item Removed from Cart');
      alert('Item Removed from Cart');
    })
  }
  Logout(){
    this.route.navigateByUrl('home');
  }
}
