import 'package:flutter/material.dart';
import './pages/product.dart';
class Products extends StatelessWidget {
  final List<String> products;
  Products(this.products) {}

  Widget _builderProductItem(BuildContext context, int index) {
    return Card(
        child: Column(
      children: <Widget>[
        Image.asset('assets/810613982_114129.jpg'),
        Text(products[index]),
        ButtonBar(
          alignment: MainAxisAlignment.center,
          children: <Widget>[
            FlatButton(
              child: Text('details'),
              onPressed: () => Navigator.push(context, MaterialPageRoute(
                builder: (BuildContext context)=>ProductPage(),
                
                )
                )
                ,
              color: Theme.of(context).primaryColorDark,
            )
          ],
        )
      ],
    ));
  }

  @override
  Widget build(BuildContext context) {
    Widget productControl = Center(
      child: Text('no cards to show , try to add new'),
    );
    if (products.length > 0) {
      productControl = ListView.builder(
        itemBuilder: _builderProductItem,
        itemCount: products.length,
      );
    }
    return productControl;
  }
}
