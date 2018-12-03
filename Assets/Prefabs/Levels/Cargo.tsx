<?xml version="1.0" encoding="UTF-8"?>
<tileset version="1.2" tiledversion="1.2.1" name="Cargo" tilewidth="80" tileheight="112" tilecount="38" columns="0">
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
   <property name="delay" type="float" value="10"/>
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
   <property name="delay" type="float" value="6"/>
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
   <object id="14" x="0" y="2.36364">
    <polygon points="0,0 2.18182,-2.27273 13,-2.36364 15.8182,0.545455 15.8182,13.7273 29.3636,13.7273 31.9091,15.6364 31.8182,27.8182 29.9091,29.5455 15.9091,29.5455 15.8182,43.6364 13.7273,45.5455 1.81818,45.6364 0,43.6364"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="5">
  <properties>
   <property name="bonus" type="bool" value="false"/>
   <property name="bonus_description" value=""/>
   <property name="delay" type="float" value="20"/>
   <property name="description" value="Cannon Supplies"/>
   <property name="infectable" type="bool" value="false"/>
   <property name="innate" type="bool" value="false"/>
   <property name="material" value="wood"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="48" height="32" source="../../Images/Pieces/1.png"/>
  <objectgroup draworder="index">
   <object id="1" x="0" y="3.09091">
    <polygon points="1.54545,1.54545 4.63636,-1.54545 43.4545,-1.36364 46.2727,1 46.1818,9 44.1818,11.0909 14.7273,11.0909 14.8182,25.1818 13.0909,27.4545 4,27.2727 1.72727,25.8182"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="6">
  <properties>
   <property name="bonus" type="bool" value="false"/>
   <property name="bonus_description" value=""/>
   <property name="delay" type="float" value="20"/>
   <property name="description" value="Golden Tigers"/>
   <property name="infectable" type="bool" value="false"/>
   <property name="innate" type="bool" value="false"/>
   <property name="material" value="stone"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="48" height="32" source="../../Images/Pieces/2.png"/>
  <objectgroup draworder="index">
   <object id="1" x="18.9091" y="0.181818">
    <polygon points="1.18181,0.999995 -1.72728,3.9091 -1.81818,17 -15.6364,17.0909 -17.6364,19.4545 -17.6364,28.7273 -16.1818,30.4545 9.81818,30.1818 11.9091,28.1818 12,14.5455 25.5455,14.5455 27.6363,11.7273 27.7272,3.18182 26.1818,1"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="7">
  <properties>
   <property name="bonus" type="bool" value="false"/>
   <property name="bonus_description" value=""/>
   <property name="delay" type="float" value="20"/>
   <property name="description" value="Miniature Piano"/>
   <property name="infectable" type="bool" value="false"/>
   <property name="innate" type="bool" value="false"/>
   <property name="material" value="wood"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="48" height="32" source="../../Images/Pieces/3.png"/>
  <objectgroup draworder="index">
   <object id="1" x="39.8182" y="3.27273">
    <polygon points="-0.818182,1.36364 -2.36364,-2.27273 -34.1818,-2.18182 -38.7273,0.181818 -38.8182,7.36364 -35.2727,11.6364 -22.6364,11.6364 -22.9091,21.7273 -18.9091,27.5455 -2.63636,27.6364 -0.909091,24.9091"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="8">
  <properties>
   <property name="bonus" type="bool" value="false"/>
   <property name="bonus_description" value=""/>
   <property name="delay" type="float" value="20"/>
   <property name="description" value="Jade Statue"/>
   <property name="infectable" type="bool" value="false"/>
   <property name="innate" type="bool" value="false"/>
   <property name="material" value="stone"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="48" height="32" source="../../Images/Pieces/4.png"/>
  <objectgroup draworder="index">
   <object id="1" x="0" y="3.27273">
    <polygon points="1.18182,1.27272 4.18182,-2 11.4545,-2.09091 14.8182,0.636365 14.8181,14 44.9091,14.0909 46.9091,15.5455 46.8182,26.0909 45.091,27.7272 3.81818,27.5454 1.09091,25.8181"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="9">
  <properties>
   <property name="bonus" type="bool" value="false"/>
   <property name="bonus_description" value=""/>
   <property name="delay" type="float" value="20"/>
   <property name="description" value="Machining Parts"/>
   <property name="infectable" type="bool" value="false"/>
   <property name="innate" type="bool" value="false"/>
   <property name="material" value="wood"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="48" height="32" source="../../Images/Pieces/5.png"/>
  <objectgroup draworder="index">
   <object id="1" x="18.6364" y="0">
    <polygon points="1.90909,1.27273 -0.727273,4 -0.818182,17.5455 -15.1818,17.6364 -17.0909,19.9091 -17.0909,29.0909 -15.2727,30.7273 9.90909,30.8182 11.9091,29.2727 12.1818,14.7273 25.5455,14.6364 28.0909,12.2727 28.0909,3.36364 26,1.36364"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="10">
  <properties>
   <property name="bonus" type="bool" value="false"/>
   <property name="bonus_description" value=""/>
   <property name="delay" type="float" value="20"/>
   <property name="description" value="Textiles"/>
   <property name="infectable" type="bool" value="false"/>
   <property name="innate" type="bool" value="false"/>
   <property name="material" value="wood"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="48" height="32" source="../../Images/Pieces/6.png"/>
  <objectgroup draworder="index">
   <object id="1" x="0.0909091" y="15.8182">
    <polygon points="1.54545,3.27273 1.54545,13.8182 3.81818,15.0909 45.2727,15.0909 46.4545,12.9091 45.9091,3.36364 42.4545,1.09091 30.1818,1 29.9091,-12.7272 27.8182,-14.5454 18.5455,-14.5455 17.5455,-12.4545 17.9091,1.09091 3.54545,1.18182"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="11">
  <properties>
   <property name="bonus" type="bool" value="false"/>
   <property name="bonus_description" value=""/>
   <property name="delay" type="float" value="20"/>
   <property name="description" value="Bundle of Rum"/>
   <property name="infectable" type="bool" value="false"/>
   <property name="innate" type="bool" value="false"/>
   <property name="material" value="wood"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="48" height="32" source="../../Images/Pieces/7.png"/>
  <objectgroup draworder="index">
   <object id="1" x="3.18182" y="15.8182">
    <polygon points="0.818182,1.36364 -1.54545,4.27273 -1.54545,12.1818 0.909091,15 40.6364,14.9091 43.5455,12.5455 43.0909,3.63636 40.5455,1 27.8182,0.818182 27.6364,-12.0909 25.0909,-14.9091 16.7273,-14.8182 13.8182,-11.7273 13.9091,1.09091"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="12">
  <properties>
   <property name="bonus" type="bool" value="false"/>
   <property name="bonus_description" value=""/>
   <property name="delay" type="float" value="20"/>
   <property name="description" value="Cannon"/>
   <property name="infectable" type="bool" value="false"/>
   <property name="innate" type="bool" value="false"/>
   <property name="material" value="stone"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="48" height="32" source="../../Images/Pieces/8.png"/>
  <objectgroup draworder="index">
   <object id="1" x="2.54545" y="0">
    <polygon points="1.27273,1.18182 -0.636364,2.90909 -0.545455,29.0909 1.09091,30.8182 27,31 28.1818,29.0909 28.5455,20.9091 42.1818,21 44.4545,19.7273 44.5455,12.0909 42.3636,10.8182 28.5455,10.7273 28,2.45455 26,1.18182"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="13">
  <properties>
   <property name="bonus" type="bool" value="false"/>
   <property name="bonus_description" value=""/>
   <property name="delay" type="float" value="20"/>
   <property name="description" value="Persian Rug"/>
   <property name="infectable" type="bool" value="false"/>
   <property name="innate" type="bool" value="false"/>
   <property name="material" value="stone"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="16" height="64" source="../../Images/Pieces/9.png"/>
  <objectgroup draworder="index">
   <object id="1" x="-0.0909091" y="2.36364">
    <polygon points="1.36364,1.09091 4.18182,-1.36363 6.63704,-1.38895 8.27045,1.50612 9.72481,-1.42078 13,-1.45454 15,0.636363 15.3636,59 13.8182,60.6364 3.27273,60.5455 1.45455,59.1818"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="14">
  <properties>
   <property name="bonus" type="bool" value="false"/>
   <property name="bonus_description" value=""/>
   <property name="delay" type="float" value="20"/>
   <property name="description" value="Timbers"/>
   <property name="infectable" type="bool" value="false"/>
   <property name="innate" type="bool" value="false"/>
   <property name="material" value="wood"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="16" height="64" source="../../Images/Pieces/10.png"/>
  <objectgroup draworder="index">
   <object id="1" x="-0.181818" y="2.72727">
    <polygon points="1.18182,0.0909087 3.36364,-1.63637 6.63607,-1.6052 7.81951,-0.230294 8.90859,-1.58356 12.9091,-1.54546 15,0.181818 15.091,58.4545 13.2728,60.3636 3.18182,60.1818 1.18182,58.6364"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="15">
  <properties>
   <property name="bonus" type="bool" value="false"/>
   <property name="bonus_description" value=""/>
   <property name="delay" type="float" value="20"/>
   <property name="description" value=""/>
   <property name="infectable" type="bool" value="false"/>
   <property name="innate" type="bool" value="false"/>
   <property name="material" value="wood"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="32" height="32" source="../../Images/Pieces/11.png"/>
  <objectgroup draworder="index">
   <object id="1" x="0.0909091" y="2.63636">
    <polygon points="1.36364,0.909091 3.54545,-1.54545 8.27273,-1.36364 10.4545,0.909091 12.3636,-1.27273 28.5455,-1.36364 30.4545,0.272727 30.4545,26 28.5455,27.8182 3.27273,27.8182 1.45455,26.1818"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="16">
  <properties>
   <property name="bonus" type="bool" value="false"/>
   <property name="bonus_description" value=""/>
   <property name="delay" type="float" value="20"/>
   <property name="description" value=""/>
   <property name="infectable" type="bool" value="false"/>
   <property name="innate" type="bool" value="false"/>
   <property name="material" value="wood"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="32" height="32" source="../../Images/Pieces/12.png"/>
  <objectgroup draworder="index">
   <object id="1" x="-0.0909091" y="2.63636">
    <polygon points="1.72727,0.909091 3.81818,-1.36364 9.54472,-1.25408 11.5453,1.48259 13.9738,-1.37926 28.9091,-1.36364 31.0909,0.636364 31,26.1818 29.3636,28 3.45455,27.9091 1.36364,26.4545"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="17">
  <properties>
   <property name="bonus" type="bool" value="false"/>
   <property name="bonus_description" value=""/>
   <property name="delay" type="float" value="20"/>
   <property name="description" value=""/>
   <property name="infectable" type="bool" value="false"/>
   <property name="innate" type="bool" value="false"/>
   <property name="material" value="metal"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="32" height="32" source="../../Images/Pieces/13.png"/>
  <objectgroup draworder="index">
   <object id="1" x="-0.0909091" y="12.5455">
    <polygon points="1.09091,0.545455 3.09091,2.63636 16.8182,2.63636 16.8182,17 18.4545,18.2727 30.4545,18.2727 31.1818,16.2727 31.0909,-4.63636 25.1818,-11.0909 3.36364,-11.1818 1.09091,-9.90909"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="18">
  <properties>
   <property name="bonus" type="bool" value="false"/>
   <property name="bonus_description" value=""/>
   <property name="delay" type="float" value="20"/>
   <property name="description" value="Sunshade"/>
   <property name="infectable" type="bool" value="false"/>
   <property name="innate" type="bool" value="false"/>
   <property name="material" value="wood"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="16" height="32" source="../../Images/Pieces/14.png"/>
  <objectgroup draworder="index">
   <object id="1" x="-0.181818" y="6.81818">
    <polygon points="1.09091,-0.181818 4,-5.72727 7.365,-5.78129 8.6376,-4.67666 9.90848,-5.6621 12.6364,-5.63636 15.3636,0 15.4336,8.09527 15.0909,21 13.1818,24.0909 3.36364,24.3636 1.90909,21.7273 1.29027,8.08641"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="19">
  <properties>
   <property name="bonus" type="bool" value="false"/>
   <property name="bonus_description" value=""/>
   <property name="delay" type="float" value="20"/>
   <property name="description" value="Sarcophagus"/>
   <property name="infectable" type="bool" value="false"/>
   <property name="innate" type="bool" value="false"/>
   <property name="material" value="stone"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="16" height="32" source="../../Images/Pieces/15.png"/>
  <objectgroup draworder="index">
   <object id="1" x="0" y="4.36364">
    <polygon points="0.909091,0.181818 3.90909,-3.27273 6.72599,-3.52729 7.72676,-2.4107 8.99928,-3.4845 11.7273,-3.45455 14.9091,0.454545 15.2727,22.5455 12.9091,26.8182 3.18182,26.7273 1,21.7273"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="20">
  <properties>
   <property name="bonus" type="bool" value="false"/>
   <property name="bonus_description" value=""/>
   <property name="delay" type="float" value="20"/>
   <property name="description" value="Gunpowder"/>
   <property name="infectable" type="bool" value="false"/>
   <property name="innate" type="bool" value="false"/>
   <property name="material" value="wood"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="16" height="16" source="../../Images/Pieces/16.png"/>
  <objectgroup draworder="index">
   <object id="1" x="-0.0909091" y="3.27273">
    <polygon points="0.818182,1.09091 3.72727,-2.18181 6.90944,-2.19443 7.6302,-1.14158 8.99523,-2.19205 12.3636,-2.36363 15,0.454545 15.1818,9.27273 12.2727,11.6364 3.90909,11.7273 1.18182,9.45455"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="21">
  <properties>
   <property name="bonus" type="bool" value="false"/>
   <property name="bonus_description" value=""/>
   <property name="delay" type="float" value="20"/>
   <property name="description" value="Loot Crate"/>
   <property name="infectable" type="bool" value="false"/>
   <property name="innate" type="bool" value="false"/>
   <property name="material" value="wood"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="16" height="16" source="../../Images/Pieces/17.png"/>
  <objectgroup draworder="index">
   <object id="1" x="0" y="1.54545">
    <polygon points="1,0.363636 2.18181,-0.454546 6.18226,-0.516438 7.09188,2.40813 8.45544,-0.398447 13.5455,-0.454546 14.8182,0.818181 14.8182,12.3637 13.1819,13.4546 2.27272,13.2727 1.18182,11.9091"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="22">
  <properties>
   <property name="bonus" type="bool" value="false"/>
   <property name="bonus_description" value=""/>
   <property name="delay" type="float" value="20"/>
   <property name="description" value="Strongbox"/>
   <property name="infectable" type="bool" value="false"/>
   <property name="innate" type="bool" value="false"/>
   <property name="material" value="metal"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="48" height="16" source="../../Images/Pieces/18.png"/>
  <objectgroup draworder="index">
   <object id="1" x="-0.0909091" y="1.90909">
    <polygon points="1.54545,0.727273 2.81818,-0.909095 13.5455,-0.727275 14.6364,2.72728 16.2727,-0.727275 37.4546,-0.909095 39.0909,0.363636 39.1818,10.9091 37.7273,12.6363 3.36363,13.0909 1.36364,11.6363"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="23">
  <properties>
   <property name="bonus" type="bool" value="false"/>
   <property name="bonus_description" value=""/>
   <property name="delay" type="float" value="20"/>
   <property name="description" value="Statue"/>
   <property name="infectable" type="bool" value="false"/>
   <property name="innate" type="bool" value="false"/>
   <property name="material" value="stone"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="48" height="64" source="../../Images/Pieces/19.png"/>
  <objectgroup draworder="index">
   <object id="1" x="18.4545" y="15.1818">
    <polygon points="0,0.545455 0.0909091,-13.3636 2.18182,-15.1818 8.72727,-15.1818 10.9091,-12.2727 10.9091,0.545455 25.8182,0.727273 27.3636,1.81818 27.4545,6.63636 26.1818,7.81818 12.6364,7.90909 12.4545,46.9091 11.5455,47.7273 -0.272727,47.9091 -1.72727,46.5455 -1.54545,8 -13.2727,7.90909 -15.9091,6.90909 -15.9091,1.63636 -13.3636,0.545455"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="24">
  <properties>
   <property name="bonus" type="bool" value="false"/>
   <property name="bonus_description" value=""/>
   <property name="delay" type="float" value="20"/>
   <property name="description" value="Steam Engine"/>
   <property name="infectable" type="bool" value="false"/>
   <property name="innate" type="bool" value="false"/>
   <property name="material" value="metal"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="48" height="48" source="../../Images/Pieces/20.png"/>
  <objectgroup draworder="index">
   <object id="1" x="16" y="1.72727">
    <polygon points="0.454545,1.36364 1.63636,-0.272724 13.7273,-0.454544 15.2727,1.36364 15.8182,14.2727 22.4545,14.2727 23.8182,16 23.9091,36.5455 22.6364,38 16,38 15.9091,44.1819 14.4545,45.4546 -11.5454,45.091 -14.9091,42.9091 -15,32.6364 -11.9091,31.1818 0.272727,31"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="25">
  <properties>
   <property name="bonus" type="bool" value="true"/>
   <property name="bonus_description" value="The Obelisk"/>
   <property name="delay" type="float" value="20"/>
   <property name="description" value="Mysterious Statue"/>
   <property name="infectable" type="bool" value="false"/>
   <property name="innate" type="bool" value="false"/>
   <property name="material" value="stone"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="32" height="112" source="../../Images/Pieces/21.png"/>
  <objectgroup draworder="index">
   <object id="1" x="0.363636" y="22.0909">
    <polygon points="0.909091,-1.18182 12.4545,-21 14.1818,-21 15.1818,-16.8182 16.1818,-20.9091 18,-21 30.3636,-1.18182 30.6364,86.6363 28.5454,88.8182 2.81818,89 0.545454,86.5454"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="26">
  <properties>
   <property name="bonus" type="bool" value="true"/>
   <property name="bonus_description" value="San Holo"/>
   <property name="delay" type="float" value="20"/>
   <property name="description" value="Strange Object"/>
   <property name="infectable" type="bool" value="false"/>
   <property name="innate" type="bool" value="false"/>
   <property name="material" value="metal"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="16" height="32" source="../../Images/Pieces/22.png"/>
  <objectgroup draworder="index">
   <object id="1" x="-0.181818" y="2.27273">
    <polygon points="1.27273,0.909091 3.18181,-1.36364 5.99717,-1.3937 7.18023,3.59779 8.81778,-1.41988 13.3636,-1.36364 15.1818,0.727273 15,26.8182 13,28.6364 3.36363,28.5455 1.54545,26.7273"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="27">
  <properties>
   <property name="bonus" type="bool" value="true"/>
   <property name="bonus_description" value="Arc of the Covenant"/>
   <property name="delay" type="float" value="20"/>
   <property name="description" value="Fancy Box"/>
   <property name="infectable" type="bool" value="false"/>
   <property name="innate" type="bool" value="false"/>
   <property name="material" value="stone"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="80" height="32" source="../../Images/Pieces/23.png"/>
  <objectgroup draworder="index">
   <object id="1" x="0" y="3">
    <polygon points="0,0 -0.0909091,-2.09091 1.09091,-3 77.8182,-2.90909 79.9091,-1.81818 79.8182,-0.0909091 58.0909,0.181818 58.3636,18.5455 80,18.7273 80,20.3636 78.9091,21 2.09091,20.9091 -0.0909091,20 -0.0909091,18.7273 21,18.7273 20.8182,-0.181818"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="28">
  <properties>
   <property name="bonus" type="bool" value="true"/>
   <property name="bonus_description" value="Kang Kong's Banana"/>
   <property name="delay" type="float" value="20"/>
   <property name="description" value="Large Fruit"/>
   <property name="infectable" type="bool" value="false"/>
   <property name="innate" type="bool" value="false"/>
   <property name="material" value="wood"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="48" height="32" source="../../Images/Pieces/24.png"/>
  <objectgroup draworder="index">
   <object id="2" x="3.72727" y="15.7273">
    <properties>
     <property name="delay" type="float" value="10"/>
     <property name="score" type="float" value="5"/>
    </properties>
    <polygon points="0,0 2.63636,0.545455 13.2728,5.18182 29.6364,5.18182 36.3637,-0.181816 40,-12 40.4546,-14.5455 42.4545,-15.4546 43.6363,-13.6364 43,5.63637 34.9091,15.0909 11.1818,15.3636 -2.63636,5 -2.63636,0.909092"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="29">
  <properties>
   <property name="bonus" type="bool" value="false"/>
   <property name="bonus_description" value=""/>
   <property name="delay" type="float" value="20"/>
   <property name="description" value="Temple Roof"/>
   <property name="infectable" type="bool" value="false"/>
   <property name="innate" type="bool" value="false"/>
   <property name="material" value="stone"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="32" height="48" source="../../Images/Pieces/25.png"/>
  <objectgroup draworder="index">
   <object id="1" x="1.0625" y="1.0625">
    <polygon points="0,1.75 -0.0606383,44.5 1.375,45.875 28.5,45.8125 29.875,44.6875 29.875,1.0625 28.8125,-0.0625 12.6874,-0.0994841 11.4999,1.14865 10.5626,-0.104358 1.5625,-0.125"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="30">
  <properties>
   <property name="bonus" type="bool" value="false"/>
   <property name="bonus_description" value=""/>
   <property name="delay" type="float" value="20"/>
   <property name="description" value="Fromage Grande"/>
   <property name="infectable" type="bool" value="false"/>
   <property name="innate" type="bool" value="false"/>
   <property name="material" value="wood"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="32" height="32" source="../../Images/Pieces/26.png"/>
  <objectgroup draworder="index">
   <object id="1" x="4.0625" y="4" width="24" height="24">
    <ellipse/>
   </object>
  </objectgroup>
 </tile>
 <tile id="31">
  <properties>
   <property name="bonus" type="bool" value="false"/>
   <property name="bonus_description" value=""/>
   <property name="delay" type="float" value="20"/>
   <property name="description" value="Sausages"/>
   <property name="infectable" type="bool" value="false"/>
   <property name="innate" type="bool" value="false"/>
   <property name="material" value="wood"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="48" height="32" source="../../Images/Pieces/27.png"/>
  <objectgroup draworder="index">
   <object id="1" x="0.9375" y="5.1875">
    <polygon points="0,0 0.0625,5.25 5.25,11 16.1875,11.125 16.25,20.8125 20,25.625 41.875,25.75 46.0625,20.6875 46.0625,16.6875 41,10.5625 30,10.6875 30,0.625 25.9375,-4.1875 4.125,-4.125"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="32">
  <properties>
   <property name="bonus" type="bool" value="false"/>
   <property name="bonus_description" value=""/>
   <property name="delay" type="float" value="20"/>
   <property name="description" value="Rat Trap"/>
   <property name="infectable" type="bool" value="false"/>
   <property name="innate" type="bool" value="false"/>
   <property name="material" value="wood"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="16" height="16" source="../../Images/Pieces/28.png"/>
  <objectgroup draworder="index">
   <object id="1" x="0.0625" y="1.9375">
    <polygon points="0.9375,1 2.4375,-0.9375 5.25,-0.875 6.875,0.8125 6.9375,4.3125 5.9375,5.375 6.9375,6.5 7,12.4375 5.875,13.4375 2.0625,13.3125 0.9375,12.25"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="33">
  <properties>
   <property name="bonus" type="bool" value="false"/>
   <property name="bonus_description" value=""/>
   <property name="delay" type="float" value="20"/>
   <property name="description" value="Sakura Gi"/>
   <property name="infectable" type="bool" value="false"/>
   <property name="innate" type="bool" value="false"/>
   <property name="material" value="wood"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="48" height="48" source="../../Images/Pieces/29.png"/>
 </tile>
 <tile id="34">
  <properties>
   <property name="bonus" type="bool" value="false"/>
   <property name="bonus_description" value=""/>
   <property name="delay" type="float" value="20"/>
   <property name="description" value="Chrimmus Tree"/>
   <property name="infectable" type="bool" value="false"/>
   <property name="innate" type="bool" value="false"/>
   <property name="material" value="wood"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="48" height="48" source="../../Images/Pieces/30.png"/>
 </tile>
 <tile id="35">
  <properties>
   <property name="bonus" type="bool" value="false"/>
   <property name="bonus_description" value=""/>
   <property name="delay" type="float" value="20"/>
   <property name="description" value="Pyramid"/>
   <property name="infectable" type="bool" value="false"/>
   <property name="innate" type="bool" value="false"/>
   <property name="material" value="stone"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="32" height="32" source="../../Images/Pieces/31.png"/>
 </tile>
 <tile id="36">
  <properties>
   <property name="bonus" type="bool" value="false"/>
   <property name="bonus_description" value=""/>
   <property name="delay" type="float" value="20"/>
   <property name="description" value="Ancient Bones"/>
   <property name="infectable" type="bool" value="false"/>
   <property name="innate" type="bool" value="false"/>
   <property name="material" value="stone"/>
   <property name="score" type="float" value="2"/>
  </properties>
  <image width="48" height="32" source="../../Images/Pieces/32.png"/>
 </tile>
 <tile id="37">
  <properties>
   <property name="infectable" type="bool" value="false"/>
   <property name="special" value="rat"/>
  </properties>
  <image width="16" height="16" source="../../Images/Pieces/rat.png"/>
 </tile>
</tileset>
