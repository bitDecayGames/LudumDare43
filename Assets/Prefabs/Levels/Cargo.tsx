<?xml version="1.0" encoding="UTF-8"?>
<tileset version="1.2" tiledversion="1.2.1" name="Cargo" tilewidth="48" tileheight="64" tilecount="5" columns="0">
 <grid orientation="orthogonal" width="1" height="1"/>
 <tile id="0">
  <properties>
   <property name="delay" type="float" value="3"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="16" height="64" source="../../Images/Pieces/bar.png"/>
  <objectgroup draworder="index">
   <object id="1" x="0.0909091" y="2.90909">
    <polygon points="0,0 -0.0909091,57.5455 3.36364,61.0909 12.9091,61.0909 15.8182,58.5455 15.9091,0 13.4545,-3 2.36364,-3"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="1">
  <properties>
   <property name="delay" type="float" value="15"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="36" height="52" source="../../Images/Pieces/l.png"/>
  <objectgroup draworder="index">
   <object id="1" x="5.54545" y="34">
    <polygon points="0,0 -3.54545,3.36364 -3.54545,13.2727 -1.18182,15.7273 25,15.9091 28.2727,13.1818 28.2727,-29.3636 25.8182,-32.0909 15.0909,-32 12.4545,-29.4545 12.4545,-0.0909091"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="2">
  <properties>
   <property name="delay" type="float" value="3"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="48" height="32" source="../../Images/Pieces/s.png"/>
  <objectgroup draworder="index">
   <object id="1" x="18.6364" y="0.0909091">
    <polygon points="0,0 -2.54545,2.63636 -2.63636,15.8182 -16.1818,15.8182 -18.5455,18.7273 -18.5455,29.5455 -16.0909,31.8182 10.6364,31.8182 13.2727,29.6364 13.1818,15.7273 27.0909,15.8182 29.2727,13.6364 29.3636,2.09091 27,-0.0909091"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="3">
  <properties>
   <property name="delay" type="float" value="3"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="32" height="32" source="../../Images/Pieces/square.png"/>
  <objectgroup draworder="index">
   <object id="1" x="0" y="2.72727">
    <polygon points="0,0 0,26.8182 2.45455,29.0909 28.8182,29.0909 31.9091,26 32,-0.181818 29.5455,-2.81818 2.09091,-2.72727"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="4">
  <properties>
   <property name="delay" type="float" value="3"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="32" height="48" source="../../Images/Pieces/t.png"/>
  <objectgroup draworder="index">
   <object id="12" x="0" y="-0.0909091" width="16" height="48.0909"/>
   <object id="13" x="12.3636" y="16" width="19.5455" height="16"/>
  </objectgroup>
 </tile>
</tileset>
