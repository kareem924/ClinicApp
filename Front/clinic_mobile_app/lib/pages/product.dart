import 'package:flutter/material.dart';
import '../products_manager.dart';
import './home.dart';
class ProductPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('test new page'),
      ),
      body: Column(
        children: <Widget>[
          Center(
            child: Text('hello product page'),
          ),
          FlatButton(
            child: Text('back'),
            onPressed:()=> Navigator.push(
                context,
                MaterialPageRoute(
                    builder: (BuildContext context) => HomePage())),
          )
        ],
      ),
    );
  }
}
