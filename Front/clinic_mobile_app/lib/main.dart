import 'package:flutter/material.dart';
import './pages/home.dart';
import 'package:flutter/rendering.dart';
main(){
  debugPaintSizeEnabled=false;
  debugPaintBaselinesEnabled=false;
   runApp(MyApp());
}
class MyApp extends StatelessWidget {
  @override
 Widget build(BuildContext context) {
    return MaterialApp(
      theme: ThemeData(
        brightness: Brightness.light,
        primarySwatch: Colors.lightBlue,
        accentColor: Colors.lightGreen
      ),
    home: HomePage(),
    );
  }
}


