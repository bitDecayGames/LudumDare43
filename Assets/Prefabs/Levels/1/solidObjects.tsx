<?xml version="1.0" encoding="UTF-8"?>
<tileset version="1.2" tiledversion="1.2.1" name="tester" tilewidth="16" tileheight="48" tilecount="2" columns="0">
 <grid orientation="orthogonal" width="1" height="1"/>
 <tile id="0">
  <image width="16" height="48" source="../../../SuperTiled2Unity/Examples/Overhead/Maps/Zoria Tileset/pillar.png"/>
  <objectgroup draworder="index">
   <object id="1" x="0.875" y="46.875">
    <properties>
     <property name="cargotype" value="pillar"/>
    </properties>
    <polygon points="0,0 -0.125,-12.25 1.75,-14.875 1.75,-29.5 -0.25,-34.625 -0.125,-46.5 13.875,-46.375 14,-34.5 12.375,-29.25 12.125,-13.875 14,-10.375 14.125,-0.125"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="1">
  <properties>
   <property name="cargotype" value="broken_pillar"/>
  </properties>
  <image width="16" height="32" source="../../../SuperTiled2Unity/Examples/Overhead/Maps/Zoria Tileset/pilllar-broken.png"/>
  <objectgroup draworder="index">
   <object id="1" x="1.25" y="30.625">
    <polygon points="0,0 -0.125,-10.625 1.5,-14.25 1.875,-27.625 4.375,-29.75 8.25,-29.75 10.875,-26.375 11.5,-13.75 13.5,-10.375 13.75,-0.125"/>
   </object>
  </objectgroup>
 </tile>
</tileset>
