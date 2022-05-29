
//COPYRIGHT TALCOTT bv THE NETHERLANDS

var worldType = 1;
var angularSpeed = 0.1; // revolutions per second
var lastTime = 0;

//..
//WEBGL renderer
var renderer = new THREE.WebGLRenderer();
////var renderer =new THREE.WebGLRenderer( { antialias: true, alpha: true } );
renderer.setSize(window.innerWidth, window.innerHeight);
//renderer.setSize(100, 100);
document.body.appendChild(renderer.domElement);

//CANVAS renderer
//var renderer = new THREE.CanvasRenderer();
//renderer.setSize(window.innerWidth, window.innerHeight);
//document.body.appendChild( renderer.domElement );

//SCENE
var scene = new THREE.Scene();
//scene = new THREE.Scene();

// add subtle ambient lighting
//var ambientLight = new THREE.AmbientLight(0x555555);
var ambientLight = new THREE.AmbientLight(0xcccccc);
scene.add(ambientLight);

// add directional light source
var directionalLight = new THREE.DirectionalLight(0x888888);
directionalLight.position.set(1, 1, 1).normalize();
scene.add(directionalLight);

// camera
//var camera = new THREE.PerspectiveCamera(45, window.innerWidth / window.innerHeight, 1, 1000);
var camera = new THREE.OrthographicCamera(window.innerWidth / -4, window.innerWidth / 4, window.innerHeight / 4, window.innerHeight / -4, 1, 1000);
camera.position.z = 700;
//scene.add(camera);

controls = new THREE.TrackballControls(camera);
//




//BASIC VALUES

 var i, d, c, g, r;
 
 var clustern = 8;


 //3D WORLD

 var worldtype = 1;
 var worldsize3d = 200;
 var cylLen = 20;
 



 var mm = new Array(5);
 for (var n = 1; n < 5 + 1; n++) {
     mm[n] = new Array(5);
 }

 

 var world = 0;
  

 //APPLICATION SPECIFIC DATA

 var cardwwx = new Array(cardn.value);
 var cardwwy = new Array(cardn.value);
 var cardwwz = new Array(cardn.value);

 var meanwwx = new Array(cardn.value);
 var meanwwy = new Array(cardn.value);
 var meanwwz = new Array(cardn.value);

 var partwx = new Array(participantn.value);
 var partwy = new Array(participantn.value);
 var partwz = new Array(participantn.value);

//ITEM CARDS
 
var m = 30;
var tm = 10;
 
 
//PREVENT DRAWING MAP TWICE AFTER KEYCODE M

var step = 0;
 

 

//CLUSTERLINES
var xc = new Array(101); var yc = new Array(101);   var zc = new Array(101);

window.requestAnimFrame = (function (callback) {
    return window.requestAnimationFrame ||
        window.webkitRequestAnimationFrame ||
        window.mozRequestAnimationFrame ||
        window.oRequestAnimationFrame ||
        window.msRequestAnimationFrame ||
        function (callback) {
            window.setTimeout(callback, 1000 / 60);
        };
})();


 


 

function showmanual(context) {

    var xxx = GetWidth() - 115;
    var yyy = GetHeight();
    context.fillText("u: more clusters", xxx, yyy - 76);
    context.fillText("d: less clusters", xxx, yyy - 64);
    context.fillText("m: toggle map type", xxx, yyy - 52);
}

function onDocumentMouseMove( event ) {

                //angleY = ( event.clientX / window.innerWidth )*2*Math.PI; 
                //angleXZ = ( event.clientY / window.innerHeight )*2*Math.PI;             

}

function reload() {


   // translatecoordinates3dWorld(worldtype);
   // BuildWorld();
}
// Rotate an object around an axis in object space
function rotateAroundObjectAxis(object, axis, radians) {

    var rotationMatrix = new THREE.Matrix4();

    rotationMatrix.setRotationAxis(axis.normalize(), radians);
    object.matrix.multiplySelf(rotationMatrix);                       // post-multiply
    object.rotation.setRotationFromMatrix(object.matrix);
}
// Rotate an object around an axis in world space (the axis passes through the object's position)       
function rotateAroundWorldAxis(object, axis, radians) {

    var rotationMatrix = new THREE.Matrix4();

    rotationMatrix.setRotationAxis(axis.normalize(), radians);
    rotationMatrix.multiplySelf(object.matrix);                       // pre-multiply
    object.matrix = rotationMatrix;
    object.rotation.setRotationFromMatrix(object.matrix);
}
 

    function rotateObjectToVector(object, xnn, ynn, znn) {

     

        //Matrix3x3 MakeMatrix( Vector3 X, Vector3 Y )  
        //{  
        //    // make sure that we actually have two unique vectors.
        //    assert( X != Y );

        //    Matrix3x3 M;  
        //    M.X = normalise( X );  
        //    M.Z = normalise( cross_product(X,Y) );
        //    M.Y = normalise( cross_product(M.Z,X) );  alleen om y weer te elimineren
        //    return M;
        //}

        var startdir = new THREE.Vector3(0, 1,0);
        var destdir = new THREE.Vector3(xnn, ynn, znn);

        startdir.normalize();
        destdir.normalize();
        var xdir = new THREE.Vector3();
        xdir = startdir;
        

        var zdir = new THREE.Vector3();
        zdir.crossVectors(startdir, destdir);
        zdir.normalize();

        var ydir = new THREE.Vector3();
        //ydir.crossVectors(zdir, startdir); //alleen om y te eliemineren..
        ydir = destdir;
        //ydir.normalize();

        object.matrixAutoUpdate = false;
         

        var orig = new THREE.Matrix4(xdir.x, xdir.y, xdir.z, 0, ydir.x, ydir.y, ydir.z, 0, zdir.x, zdir.y, zdir.z, 0, 0, 0, 0, 0);
        var orig2 = new THREE.Matrix3(xdir.x, xdir.y, xdir.z, ydir.x, ydir.y, ydir.z, zdir.x, zdir.y, zdir.z); 
        var inv2 = new THREE.Matrix3();
        inv2.getInverse(orig);
        var inv2i = new THREE.Matrix3(inv2.elements[3], inv2.elements[0], inv2.elements[6], inv2.elements[4], inv2.elements[1], inv2.elements[7], inv2.elements[5], inv2.elements[2], inv2.elements[8]);

 

        var result = new THREE.Matrix3();
      

        result.elements[0] = inv2i.elements[0] * orig2.elements[0] + inv2i.elements[3] * orig2.elements[1] + inv2i.elements[6] * orig2.elements[2];
        result.elements[1] = inv2i.elements[1] * orig2.elements[0] + inv2i.elements[4] * orig2.elements[1] + inv2i.elements[7] * orig2.elements[2];
        result.elements[2] = inv2i.elements[2] * orig2.elements[0] + inv2i.elements[5] * orig2.elements[1] + inv2i.elements[8] * orig2.elements[2];

        result.elements[3] = inv2i.elements[0] * orig2.elements[3] + inv2i.elements[3] * orig2.elements[4] + inv2i.elements[6] * orig2.elements[5];
        result.elements[4] = inv2i.elements[1] * orig2.elements[3] + inv2i.elements[4] * orig2.elements[4] + inv2i.elements[7] * orig2.elements[5];
        result.elements[5] = inv2i.elements[2] * orig2.elements[3] + inv2i.elements[5] * orig2.elements[4] + inv2i.elements[8] * orig2.elements[5];

        result.elements[6] = inv2i.elements[0] * orig2.elements[6] + inv2i.elements[3] * orig2.elements[7] + inv2i.elements[6] * orig2.elements[8];
        result.elements[7] = inv2i.elements[1] * orig2.elements[6] + inv2i.elements[4] * orig2.elements[7] + inv2i.elements[7] * orig2.elements[8];
        result.elements[8] = inv2i.elements[2] * orig2.elements[6] + inv2i.elements[5] * orig2.elements[7] + inv2i.elements[8] * orig2.elements[8];

         


       // ook goed!
       // object.matrix.elements[0] = result.elements[0];
       // object.matrix.elements[1] = result.elements[1];
       // object.matrix.elements[2] = result.elements[2];

       // object.matrix.elements[4] = result.elements[3];
       // object.matrix.elements[5] = result.elements[4];
       // object.matrix.elements[6] = result.elements[5];

       // object.matrix.elements[8] = result.elements[6];
       // object.matrix.elements[9] = result.elements[7];
       // object.matrix.elements[10] = result.elements[8];

        //beide goed
        object.matrix.elements[0] = result.elements[0];
        object.matrix.elements[1] = result.elements[3];
        object.matrix.elements[2] = result.elements[6];

        object.matrix.elements[4] = result.elements[1];
        object.matrix.elements[5] = result.elements[4];
        object.matrix.elements[6] = result.elements[7];

        object.matrix.elements[8] = -result.elements[2];
        object.matrix.elements[9] = -result.elements[5];
        object.matrix.elements[10] = -result.elements[8];


        object.matrix.elements[12] = xnn * worldsize3d;
        object.matrix.elements[13] = ynn * worldsize3d;
        object.matrix.elements[14] = znn * worldsize3d;

        object.matrix.elements[3] = 0;
        object.matrix.elements[7] = 0;
        object.matrix.elements[11] = 0;


        //var pos = new THREE.Vector3(xnn * 200, ynn * 200, znn * 200);

        //object.matrix.setPosition(pos);
 

    }



    function rotateToVector(startdir,destdir) {



        //Matrix3x3 MakeMatrix( Vector3 X, Vector3 Y )  
        //{  
        //    // make sure that we actually have two unique vectors.
        //    assert( X != Y );

        //    Matrix3x3 M;  
        //    M.X = normalise( X );  
        //    M.Z = normalise( cross_product(X,Y) );
        //    M.Y = normalise( cross_product(M.Z,X) );  alleen om y weer te elimineren
        //    return M;
        //}

        //var startdir = new THREE.Vector3(0, 1, 0);
        //var destdir = new THREE.Vector3(xnn, ynn, znn);

        startdir.normalize();
        destdir.normalize();
        var xdir = new THREE.Vector3();
        xdir = startdir;


        var zdir = new THREE.Vector3();
        zdir.crossVectors(startdir, destdir);
        zdir.normalize();

        var ydir = new THREE.Vector3();
        //ydir.crossVectors(zdir, startdir); //alleen om y te eliemineren..
        ydir = destdir;
        //ydir.normalize();

         
        var orig = new THREE.Matrix4(xdir.x, xdir.y, xdir.z, 0, ydir.x, ydir.y, ydir.z, 0, zdir.x, zdir.y, zdir.z, 0, 0, 0, 0, 0);
        var orig2 = new THREE.Matrix3(xdir.x, xdir.y, xdir.z, ydir.x, ydir.y, ydir.z, zdir.x, zdir.y, zdir.z);
        var inv2 = new THREE.Matrix3();
        inv2.getInverse(orig);
        var inv2i = new THREE.Matrix3(inv2.elements[3], inv2.elements[0], inv2.elements[6], inv2.elements[4], inv2.elements[1], inv2.elements[7], inv2.elements[5], inv2.elements[2], inv2.elements[8]);



        var result = new THREE.Matrix3();


        result.elements[0] = inv2i.elements[0] * orig2.elements[0] + inv2i.elements[3] * orig2.elements[1] + inv2i.elements[6] * orig2.elements[2];
        result.elements[1] = inv2i.elements[1] * orig2.elements[0] + inv2i.elements[4] * orig2.elements[1] + inv2i.elements[7] * orig2.elements[2];
        result.elements[2] = inv2i.elements[2] * orig2.elements[0] + inv2i.elements[5] * orig2.elements[1] + inv2i.elements[8] * orig2.elements[2];

        result.elements[3] = inv2i.elements[0] * orig2.elements[3] + inv2i.elements[3] * orig2.elements[4] + inv2i.elements[6] * orig2.elements[5];
        result.elements[4] = inv2i.elements[1] * orig2.elements[3] + inv2i.elements[4] * orig2.elements[4] + inv2i.elements[7] * orig2.elements[5];
        result.elements[5] = inv2i.elements[2] * orig2.elements[3] + inv2i.elements[5] * orig2.elements[4] + inv2i.elements[8] * orig2.elements[5];

        result.elements[6] = inv2i.elements[0] * orig2.elements[6] + inv2i.elements[3] * orig2.elements[7] + inv2i.elements[6] * orig2.elements[8];
        result.elements[7] = inv2i.elements[1] * orig2.elements[6] + inv2i.elements[4] * orig2.elements[7] + inv2i.elements[7] * orig2.elements[8];
        result.elements[8] = inv2i.elements[2] * orig2.elements[6] + inv2i.elements[5] * orig2.elements[7] + inv2i.elements[8] * orig2.elements[8];

        return result
    }


   

    function drawconceptmap3dWorld() {

       

        readdataall();
        translatecoordinates3dWorld(worldtype);


        cc.onmousedown = "";
        cc.onmousemove = "";

        //document.addEventListener('mousemove', onDocumentMouseMove, false);
        //onkeydown = keydown;

        cc.height = GetHeight(); cc.width = GetWidth();

        cc.style.position = "absolute";
        cc.top = 0;
        cc.left = 0;

        cc.style.backgroundColor = "transparent";
       

        drawworld3d(worldtype);
        drawitems()

        var meanwx, meanwy, meanwz;
        for (var c = 1; c < clustern + 1; c++) {

            meanwx = 0; meanwy = 0; meanwz = 0;
            for (var i = 1; i < groupsn3[clustern][c] + 1; i++) {

                meanwx += cardwwx[groups3[clustern][c][i]];
                meanwy += cardwwy[groups3[clustern][c][i]];
                meanwz += cardwwz[groups3[clustern][c][i]];

            }

            meanwwx[c] = meanwx / groupsn3[clustern][c];
            meanwwy[c] = meanwy / groupsn3[clustern][c];
            meanwwz[c] = meanwz / groupsn3[clustern][c];

        }

        drawclusterlines();
        drawparticipants();

        // plane
        //var plane = new THREE.Mesh(new THREE.PlaneGeometry(600, 600), new THREE.MeshBasicMaterial({
        //    color: 0x00ff00
        //}));
        //plane.overdraw = true;
        //scene.add(plane);

        //var xn = 0.577350269, yn = 0.577350269, zn = 0.577350269;
        //var cyl = new THREE.Mesh(new THREE.CylinderGeometry(20, 20, 380, 20, 20, false), new THREE.MeshLambertMaterial({
        //    color: 0xff0000
        //}));
        //rotateObjectToVector(cyl, xn, yn, zn)
        //scene.add(cyl);




        // create wrapper object that contains three.js objects
        var three = {
            renderer: renderer,
            camera: camera,
            //plane: plane,
            scene: scene
            //cylinder11: cylinder1,
            //cylinder22: cylinder2,

            //sphere: sphere

        };

        animate(lastTime, angularSpeed, three);
        showmanual(cctx);

    }

    function drawworld3d(type) {
       
            var mapB = THREE.ImageUtils.loadTexture("../images/ariadne for cm.png");
            //var mapB = THREE.ImageUtils.loadTexture("images/c2.png");
            // cylinder
            var material = new THREE.MeshLambertMaterial({

                color: 0x0000ff
            });
            var color1 = new THREE.Color(0xff0000);
            if (type==1) {
            var sphere = new THREE.Mesh(new THREE.SphereGeometry(worldsize3d, 50, 50), new THREE.MeshLambertMaterial({
                map: mapB,   //,
                transparent: true
            }));
            }
             if (type==2) {
                 var sphere = new THREE.Mesh(new THREE.SphereGeometry(worldsize3d/2, 50, 50), new THREE.MeshLambertMaterial({
                map: mapB,   //,
                transparent: true
            }));
             }
            //sphere.materials[0].opacity = .8;
            sphere.material.opacity = .8;
            sphere.overdraw = true;
            scene.add(sphere);
       
    }

    function drawitems() {

        var itemWC = new Array(cardn.value);
        var ii = 0;

     
        for (var c = 1; c < clustern + 1; c++) {

           
            for (var i = 1; i < groupsn3[clustern][c] + 1; i++) {
                

                var radius = parseInt(itemrating[groups3[clustern][c][i]] * 2);
                if (isNaN(radius)) radius = 5;
                ii += 1;

                switch (c) {

                    case 1:
                        itemWC[ii] = new THREE.Mesh(new THREE.CylinderGeometry(radius, radius, cylLen, 20, 20, false), new THREE.MeshLambertMaterial({
                            color: 0xff0000
                        }));
                        break;
                    case 2:
                        itemWC[ii] = new THREE.Mesh(new THREE.CylinderGeometry(radius, radius, cylLen, 20, 20, false), new THREE.MeshLambertMaterial({
                            color: 0x00ff00
                        }));
                        break;
                    case 3:
                        itemWC[ii] = new THREE.Mesh(new THREE.CylinderGeometry(radius, radius, cylLen, 20, 20, false), new THREE.MeshLambertMaterial({
                            color: 0xff00ff
                        }));

                        break;
                    case 4:
                        itemWC[ii] = new THREE.Mesh(new THREE.CylinderGeometry(radius, radius, cylLen, 20, 20, false), new THREE.MeshLambertMaterial({
                            color: 0xffff00
                        }));
                        break;
                    case 5:
                        itemWC[ii] = new THREE.Mesh(new THREE.CylinderGeometry(radius, radius, cylLen, 20, 20, false), new THREE.MeshLambertMaterial({
                            color: 0x00ffff
                        }));
                        break;
                    case 6:
                        itemWC[ii] = new THREE.Mesh(new THREE.CylinderGeometry(radius, radius, cylLen, 20, 20, false), new THREE.MeshLambertMaterial({
                            color: 0xffffff
                        }));
                        break;
                    case 7:
                        itemWC[ii] = new THREE.Mesh(new THREE.CylinderGeometry(radius, radius, cylLen, 20, 20, false), new THREE.MeshLambertMaterial({
                            color: 0x808080
                        }));
                        break;
                    case 8:
                        itemWC[ii] = new THREE.Mesh(new THREE.CylinderGeometry(radius, radius, cylLen, 20, 20, false), new THREE.MeshLambertMaterial({
                            color: 0x800040
                        }));
                        break;
                    case 9:
                        itemWC[ii] = new THREE.Mesh(new THREE.CylinderGeometry(radius, radius, cylLen, 20, 20, false), new THREE.MeshLambertMaterial({
                            color: 0x000000
                        }));
                        break;
                    case 10:
                        itemWC[ii] = new THREE.Mesh(new THREE.CylinderGeometry(radius, radius, cylLen, 20, 20, false), new THREE.MeshLambertMaterial({
                            color: 0x000000
                        }));
                        break;
                    case 11:
                        itemWC[ii] = new THREE.Mesh(new THREE.CylinderGeometry(radius, radius, cylLen, 20, 20, false), new THREE.MeshLambertMaterial({
                            color: 0x000000
                        }));
                        break;
                    case 12:
                        itemWC[ii] = new THREE.Mesh(new THREE.CylinderGeometry(radius, radius, cylLen, 20, 20, false), new THREE.MeshLambertMaterial({
                            color: 0x000000
                        }));
                        break;
                    case 13:
                        itemWC[ii] = new THREE.Mesh(new THREE.CylinderGeometry(radius, radius, cylLen, 20, 20, false), new THREE.MeshLambertMaterial({
                            color: 0x000000
                        }));
                        break;
                    case 14:
                        itemWC[ii] = new THREE.Mesh(new THREE.CylinderGeometry(radius, radius, cylLen, 20, 20, false), new THREE.MeshLambertMaterial({
                            color: 0x000000
                        }));
                        break;
                    case 15:
                        itemWC[ii] = new THREE.Mesh(new THREE.CylinderGeometry(radius, radius, cylLen, 20, 20, false), new THREE.MeshLambertMaterial({
                            color: 0x000000
                        }));
                        break;
                    case 16:
                        itemWC[ii] = new THREE.Mesh(new THREE.CylinderGeometry(radius, radius, cylLen, 20, 20, false), new THREE.MeshLambertMaterial({
                            color: 0x000000
                        }));
                        break;
                    case 17:
                        itemWC[ii] = new THREE.Mesh(new THREE.CylinderGeometry(radius, radius, cylLen, 20, 20, false), new THREE.MeshLambertMaterial({
                            color: 0x000000
                        }));
                        break;
                    case 18:
                        itemWC[ii] = new THREE.Mesh(new THREE.CylinderGeometry(radius, radius, cylLen, 20, 20, false), new THREE.MeshLambertMaterial({
                            color: 0x000000
                        }));
                        break;
                    case 18:
                        itemWC[ii] = new THREE.Mesh(new THREE.CylinderGeometry(radius, radius, cylLen, 20, 20, false), new THREE.MeshLambertMaterial({
                            color: 0x000000
                        }));
                        break;
                    case 20:
                        itemWC[ii] = new THREE.Mesh(new THREE.CylinderGeometry(radius, radius, cylLen, 20, 20, false), new THREE.MeshLambertMaterial({
                            color: 0x000000
                        }));
                        break;
                }

                rotateObjectToVector(itemWC[ii], cardwwx[groups3[clustern][c][i]], cardwwy[groups3[clustern][c][i]], cardwwz[groups3[clustern][c][i]], 0);
                scene.add(itemWC[ii]);

            }
 
        }
    }


    function drawclusterlines() {
        for (var c = 1; c < clustern + 1; c++) {
            
            clusterlinecoordinates(c);

            var linematerial = new THREE.LineBasicMaterial({
                color: 0x0000ff
            });
            //var ribbonmaterial = new THREE.MeshBasicMaterial({ color: 0xffffff, vertexColors: true, side: THREE.DoubleSide });
            var clusterline = new THREE.Geometry();


            for (var r = 1; r <= 100; r++) {

                //cctx.lineTo(xc[r], yc[r]);

                //zc[r] = sign(zc[r]) * Math.pow((1 - (Math.pow(xc[r], 2) + Math.pow(yc[r], 2))), .5);

                if (worldtype == 1) {
                    var xcc = xc[r];
                    var ycc = yc[r];
                    var zcc = zc[r];

                    var vvar = Math.pow(Math.pow(xcc, 2) + Math.pow(ycc, 2) + Math.pow(zcc, 2), .5);
                    xc[r] = (1 + cylLen / worldsize3d) * xcc / vvar;
                    yc[r] = (1 + cylLen / worldsize3d) * ycc / vvar;
                    zc[r] = (1 + cylLen / worldsize3d) * zcc / vvar;
                }
                clusterline.vertices.push(new THREE.Vector3(xc[r] * worldsize3d, yc[r] * worldsize3d, zc[r] * worldsize3d));


            }
            var line = new THREE.Line(clusterline, linematerial);
            //var line = new THREE.Ribbon(10 % 2 ? geometry : clusterline, ribbonmaterial);
            scene.add(line);

        }
    }

    function drawparticipants() {
        for (var p = 1; p < participantn + 1; p++) {

            var linematerial = new THREE.LineBasicMaterial({
                color: 0x0000ff
            });
            
            var gline = new THREE.Geometry();
            gline.vertices.push(new THREE.Vector3(partwx[p] * worldsize3d, partwy[p] * worldsize3d, partwz[p] * worldsize3d));
            gline.vertices.push(new THREE.Vector3(partwx[p] * worldsize3d * 1.2, partwy[p] * worldsize3d * 1.2, partwz[p] * worldsize3d * 1.2));
            var line = new THREE.Line(gline, linematerial);
            scene.add(line);

            var partsphere = new THREE.Mesh(new THREE.SphereGeometry(4, 50, 50), new THREE.MeshLambertMaterial({
                color: 0xFF0000
            }));

            partsphere.position.set(partwx[p] * worldsize3d * 1.2, partwy[p] * worldsize3d * 1.2, partwz[p] * worldsize3d * 1.2);
            //rotateObjectToVector(partsphere, participantdr[p][1][rateToUse], participantdr[p][2][rateToUse], participantdr[p][3][rateToUse], 0);
            scene.add(partsphere);
            //if (Math.pow(Math.pow(participantdr[p][1][rateToUse], 2) + Math.pow(participantdr[p][2][rateToUse], 2) ,.5)> pSig) {
            //     

        }
    }

    function clusterlinecoordinates(c) {



        var xl = 9999; var xh = -9999; var yl = 9999; var yh = -9999;
        var xll = new Array(101); var xli = new Array(101); var xhh = new Array(101); var yll = new Array(101); var yll2 = new Array(101); var yhh = new Array(101);

        for (var r = 1; r <= 100; r++) {
            xll[r] = 9999; xhh[r] = -9999; yll[r] = 9999; yll2[r] = 9999; yhh[r] = -9999;
        }
        var meanwx = 0; var meanwy = 0; var meanwz = 0; var nn = 0;
        for (var i = 1; i < groupsn3[clustern][c] + 1; i++) {

            meanwx += cardwwx[groups3[clustern][c][i]];
            meanwy += cardwwy[groups3[clustern][c][i]];
            meanwz += cardwwz[groups3[clustern][c][i]];
            nn += 1;

        }
        meanwx = meanwx / nn;
        meanwy = meanwy / nn;
        meanwz = meanwz / nn;

        var start = new THREE.Vector3(0, 0, 1);
        var dest = new THREE.Vector3(meanwx, meanwy, meanwz)

        var rotmatrixTo = rotateToVector(start, dest);
        var rotmatrixBack = rotateToVector(dest, start);



        if (meanwx != 0) {

            for (var i = 1; i < groupsn3[clustern][c] + 1; i++) {

                var xx = rotmatrixTo.elements[0] * cardwwx[groups3[clustern][c][i]] + rotmatrixTo.elements[1] * cardwwy[groups3[clustern][c][i]] + rotmatrixTo.elements[2] * cardwwz[groups3[clustern][c][i]];
                var yy = rotmatrixTo.elements[3] * cardwwx[groups3[clustern][c][i]] + rotmatrixTo.elements[4] * cardwwy[groups3[clustern][c][i]] + rotmatrixTo.elements[5] * cardwwz[groups3[clustern][c][i]];
                var zz = rotmatrixTo.elements[6] * cardwwx[groups3[clustern][c][i]] + rotmatrixTo.elements[7] * cardwwy[groups3[clustern][c][i]] + rotmatrixTo.elements[8] * cardwwz[groups3[clustern][c][i]];
                var zzzz = rotmatrixTo.elements[6] * meanwx + rotmatrixTo.elements[7] * meanwy + rotmatrixTo.elements[8] * meanwz;

                for (var r = 1; r <= 100; r++) {


                    var x = xx * Math.cos(2 * r / 100 * Math.PI) - yy * Math.sin(2 * r / 100 * Math.PI);   //cos.x - sin.y
                    var y = xx * Math.sin(2 * r / 100 * Math.PI) + yy * Math.cos(2 * r / 100 * Math.PI);  // sin.x + cos.y
                    var z = zz;

                    var plusx = sign(x) * .08
                    var plusy = sign(y) * .08
                    x = x + plusx;
                    //y = y + plusy;
                    if (x < xll[r]) { xll[r] = x; yll[r] = y; zc[r] = z };
                }
            }
            for (var r = 1; r <= 100; r++) {

                //straight lines
                var xxx = xll[r] * Math.cos(-2 * r / 100 * Math.PI) - yll[r] * Math.sin(-2 * r / 100 * Math.PI);
                var yyy = xll[r] * Math.sin(-2 * r / 100 * Math.PI) + yll[r] * Math.cos(-2 * r / 100 * Math.PI);

                xc[r] = rotmatrixBack.elements[0] * xxx + rotmatrixBack.elements[1] * yyy + rotmatrixBack.elements[2] * zc[r];
                yc[r] = rotmatrixBack.elements[3] * xxx + rotmatrixBack.elements[4] * yyy + rotmatrixBack.elements[5] * zc[r];
                zc[r] = rotmatrixBack.elements[6] * xxx + rotmatrixBack.elements[7] * yyy + rotmatrixBack.elements[8] * zc[r];

                //xc[r] = rotmatrixBack.elements[0] * xxx + rotmatrixBack.elements[1] * yyy + rotmatrixBack.elements[2] * zzzz;
                // yc[r] = rotmatrixBack.elements[3] * xxx + rotmatrixBack.elements[4] * yyy + rotmatrixBack.elements[5] * zzzz;
                //  zc[r] = rotmatrixBack.elements[6] * xxx + rotmatrixBack.elements[7] * yyy + rotmatrixBack.elements[8] * zzzz;


                //roundings
                //xc[r] = xll[r] * Math.cos(-2 * r / 100 * Math.PI) - yll2[r] * Math.sin(-2 * r / 100 * Math.PI);
                //yc[r] = xll[r] * Math.sin(-2 * r / 100 * Math.PI) + yll2[r] * Math.cos(-2 * r / 100 * Math.PI);

                //beter roundings
                //xc[r] = xll[r] * Math.cos(-2 * r / 100 * Math.PI) - (yll[r] + yll2[r]) / 2 * Math.sin(-2 * r / 100 * Math.PI);
                //yc[r] = xll[r] * Math.sin(-2 * r / 100 * Math.PI) + (yll[r] + yll2[r]) / 2 * Math.cos(-2 * r / 100 * Math.PI);


                //xc[r] = xc[r] + meanwx;
                //yc[r] = yc[r] + meanwy;


                //easy straight lines
                //xc[r] = cardwwx[xli[r]];
                //yc[r] = cardwwy[xli[r]];

            }
            // even smoother roundings
            for (var r = 5; r <= 96; r++) {
                // xc[r] = (xc[r - 2] + xc[r - 1] + xc[r] + xc[r + 1] + xc[r + 2]) / 5;
                // yc[r] = (yc[r - 2] + yc[r - 1] + yc[r] + yc[r + 1] + yc[r + 2]) / 5;
            }
        }
    }

    function drawiteminfo(c) {

        var posy = 100;
        var posx = 20;

        var my = 14;
        //for (var c = 1; c < clustern + 1; c++) {

        cctx.fillText("NUMBER OF CLUSTERS " + clustern, posx, posy);
        posy += 1.5 * my;
        cctx.fillText("CLUSTER " + c, posx, posy);
        posy += .5 * my;

        for (var i = 1; i < groupsn3[clustern][c] + 1; i++) {

            posy += my;

            var xw = cardwwx[groups3[clustern][c][i]];
            var yw = cardwwy[groups3[clustern][c][i]];
            var zw = cardwwz[groups3[clustern][c][i]];

            var xr = itemx[groups3[clustern][c][i]];
            var yr = itemy[groups3[clustern][c][i]];
            var zr = itemz[groups3[clustern][c][i]];

            var varr = Math.pow(xr, 2) + Math.pow(yr, 2) + Math.pow(zr, 2);
            var zrr = Math.pow(zr, 2);
            varr = parseInt((1 - varr) * 100) / 100;
            zrr = parseInt((zrr) * 100) / 100;
            cctx.fillText(varr, posx, posy);
            cctx.fillText(zrr, posx + 50, posy);
            cctx.fillText(cardt[groups3[clustern][c][i]], posx + 100, posy);

        }
        posy += 2 * my;

        //} 
    }

    function animate(lastTime, angularSpeed, three) {
        // update
        var date = new Date();
        var time = date.getTime();
        var timeDiff = time - lastTime;
        var angleChange = angularSpeed * timeDiff * 2 * Math.PI / 1000;
        //itemW1.position.x += .01;
        //three.cylinder11.rotation.x += angleChange;
        //three.cylinder22.rotation.y += angleChange;
        //three.plane.rotation.x += angleChange;
        //three.camera.rotation.x += angleChange;
        //three.camera.position.x +=.2;
        //three.camera.position.z -=.2;

        //three.camera.position.x += ( mouseX - three.camera.position.x ) * .05;
        //three.camera.position.y += ( - mouseY - three.camera.position.y ) * .05;
        //three.camera.rotation.y  = -1*angleY;

        //three.camera.rotation.x  = -1*angleXZ;

        //three.camera.position.x =0 * Math.cos(angle * Math.PI) - 700 * Math.sin(angle * Math.PI);   //cos.x - sin.y
        //three.camera.position.z =0 * Math.sin(angle * Math.PI) + 700 * Math.cos(angle * Math.PI);  // sin.x + cos.y

        // three.camera.position.y =posY*100;
        //var posX = 0 * Math.cos(angleY) - 700 * Math.sin(angleY);   //cos.x - sin.y
        //var posZ = 0 * Math.sin(angleY) + 700 * Math.cos(angleY);  // sin.x + cos.y

        //three.camera.position.x = posX;
        //three.camera.position.z == posZ;

        //three.scene.remove(line);
        //three.line.remove();
        //three.sphere.visible = false; ;
        //three.scene.remove();
        lastTime = time;


        controls.update();

        mm[1][1] = controls.object.matrix.elements[0];
        mm[1][2] = controls.object.matrix.elements[4];
        mm[1][3] = controls.object.matrix.elements[8];
        mm[1][4] = controls.object.matrix.elements[12];

        mm[2][1] = controls.object.matrix.elements[1];
        mm[2][2] = controls.object.matrix.elements[5];
        mm[2][3] = controls.object.matrix.elements[9];
        mm[2][4] = controls.object.matrix.elements[13];

        mm[3][1] = controls.object.matrix.elements[2];
        mm[3][2] = controls.object.matrix.elements[6];
        mm[3][3] = controls.object.matrix.elements[10];
        mm[3][4] = controls.object.matrix.elements[14];

        mm[4][1] = controls.object.matrix.elements[3];
        mm[4][2] = controls.object.matrix.elements[7];
        mm[4][3] = controls.object.matrix.elements[11];
        mm[4][4] = controls.object.matrix.elements[15];


        cctx.clearRect(0, 0, cc.width, cc.height);
        
        //cctx.fillText(mm[1][1], 50, 150);
        //cctx.fillText(mm[1][2], 50, 160);
        //cctx.fillText(mm[1][3], 50, 170);
        //cctx.fillText(mm[1][4], 50, 180);

        //cctx.fillText(mm[2][1], 200, 150);
        //cctx.fillText(mm[2][2], 200, 160);
        //cctx.fillText(mm[2][3], 200, 170);
        //cctx.fillText(mm[2][4], 200, 180);

        //cctx.fillText(mm[3][1], 350, 150);
        //cctx.fillText(mm[3][2], 350, 160);
        //cctx.fillText(mm[3][3], 350, 170);
        //cctx.fillText(mm[3][4], 350, 180);

        //cctx.fillText(mm[4][1], 500, 150);
        //cctx.fillText(mm[4][2], 500, 160);
        //cctx.fillText(mm[4][3], 500, 170);
        //cctx.fillText(mm[4][4], 500, 180);
 

        var clusH = 0;
        var mxxxH = -9999;
        var myyyH = -9999;
        var mzzzH = -9999;
        for (var c = 1; c < clustern + 1; c++) {

            var mxxx = mm[1][1] * meanwwx[c] + mm[2][1] * meanwwy[c] + mm[3][1] * meanwwz[c];
            var myyy = mm[1][2] * meanwwx[c] + mm[2][2] * meanwwy[c] + mm[3][2] * meanwwz[c];
            var mzzz = mm[1][3] * meanwwx[c] + mm[2][3] * meanwwy[c] + mm[3][3] * meanwwz[c];
            var myyy = -myyy;

            if (mzzz > mzzzH) {
                mxxxH = mxxx;
                myyyH = myyy;
                mzzzH = mzzz;
                clusH = c;
            }
        }

        var xx = parseInt(window.innerWidth / 2 + mxxxH * (400 + cylLen));  //+ length pole
        var yy = parseInt(window.innerHeight / 2 + myyyH * (400 + cylLen));
        
        var clustername = "CLUSTER " + parseInt(clusH);
        var metrics = cctx.measureText(clustername);

        cctx.fillStyle = "red";
        cctx.font = '24pt Calibri';
        cctx.fillText(clustername, xx - metrics.width / 2, yy + 12);
       
        cctx.fillStyle = "black";
        cctx.font = '9pt Calibri';
        drawiteminfo(clusH);

       
        for (var i = 0; i < cardn + 1; i++) {


            var xxx = mm[1][1] * cardwwx[i] + mm[2][1] * cardwwy[i] + mm[3][1] * cardwwz[i];
            var yyy = mm[1][2] * cardwwx[i] + mm[2][2] * cardwwy[i] + mm[3][2] * cardwwz[i];
            var zzz = mm[1][3] * cardwwx[i] + mm[2][3] * cardwwy[i] + mm[3][3] * cardwwz[i];
            var yyy = -yyy;



            if (zzz > 0) {

                var xx = window.innerWidth / 2 + xxx * (2*worldsize3d + cylLen);  //+ length pole
                var yy = window.innerHeight / 2 + yyy * (2 * worldsize3d + cylLen);

                metrics = cctx.measureText(i)
                //wraptext_oldsign_old(cctx, itemrating[i] + " " + cardt[i], xx, 20 + yy, 250, 16, sign(xxx) * 1);
                cctx.fillText(i, xx - metrics.width / 2, yy + 12);
            }
        }
        for (var p = 1; p < participantn + 1; p++) {
           

            var xxx = mm[1][1] * partwx[p] + mm[2][1] * partwy[p] + mm[3][1] * partwz[p];
            var yyy = mm[1][2] * partwx[p] + mm[2][2] * partwy[p] + mm[3][2] * partwz[p];
            var zzz = mm[1][3] * partwx[p] + mm[2][3] * partwy[p] + mm[3][3] * partwz[p];
            var yyy = -yyy;
            
            if (zzz > 0) {

                var xx = window.innerWidth / 2 + xxx * (2.4 * worldsize3d + cylLen);  //+ length pole
                var yy = window.innerHeight / 2 + yyy * (2.4 * worldsize3d + cylLen);

                metrics = cctx.measureText(partnames[p])
                //wraptext_oldsign_old(cctx, itemrating[i] + " " + cardt[i], xx, 20 + yy, 250, 16, sign(xxx) * 1);
                cctx.fillText(partnames[p], xx - metrics.width / 2, yy + 12);
            }


        }

        // render
        three.renderer.render(three.scene, three.camera);

        // request new frame
        requestAnimFrame(function () {
            if (solutionDims == 3 && sheetNumber == 3) {
                animate(lastTime, angularSpeed, three);
            }
        });
    }



    function translatecoordinates3dWorld(translationType) {
        var varr = 0;

        if (translationType == 1) {  // x+y+z=1
            for (i = 1; i < cardn + 1; i++) {

                varr = Math.pow(Math.pow(itemx[i], 2) + Math.pow(itemy[i], 2) + Math.pow(itemz[i], 2), .5);
                cardwwx[i] = itemx[i] / varr;
                cardwwy[i] = itemy[i] / varr;
                cardwwz[i] = itemz[i] / varr;


            }
            for (var p = 1; p < participantn + 1; p++) {

                varr = Math.pow(Math.pow(participantdr[p][1][rateToUse], 2) + Math.pow(participantdr[p][2][rateToUse], 2) + Math.pow(participantdr[p][3][rateToUse], 2), .5);

                if (varr > 0) {
                    partwx[p] = participantdr[p][1][rateToUse] / varr;
                    partwy[p] = participantdr[p][2][rateToUse] / varr;
                    partwz[p] = participantdr[p][3][rateToUse] / varr;
                }
                else {
                    partwx[p] = 0;
                    partwy[p] = 0;
                    partwz[p] = 0;
                }
            }

        }
        if (translationType == 2) {  // no extra translation 
            for (i = 1; i < cardn + 1; i++) {

                cardwwx[i] = itemx[i];
                cardwwy[i] = itemy[i];
                cardwwz[i] = itemz[i];

            }
            for (var p = 1; p < participantn + 1; p++) {

                varr = Math.pow(Math.pow(participantdr[p][1][rateToUse], 2) + Math.pow(participantdr[p][2][rateToUse], 2) + Math.pow(participantdr[p][3][rateToUse], 2), .5);
                if (varr > 0) {
                    partwx[p] = participantdr[p][1][rateToUse] / varr;
                    partwy[p] = participantdr[p][2][rateToUse] / varr;
                    partwz[p] = participantdr[p][3][rateToUse] / varr;
                }
                else
                {
                    partwx[p] = 0;
                    partwy[p] = 0;
                    partwz[p] = 0;
                }
            }
        }
    }



    function drawcardsandgroupsworld() {


    }



    //wraptext_old(context, text, x, y, maxWidth, lineHeight);

    function wraptext_oldsign_old(context, text, x, y, maxWidth, lineHeight, posneg) {
        var words = text.split(' ');
        var line = '';
        //var lineN = 0;

        for (var n = 0; n < words.length; n++) {

            var testLine = line + words[n] + ' ';
            var metrics = context.measureText(testLine);
            var testWidth = metrics.width;
            if (testWidth > maxWidth) {
 
                if (posneg == 1) {
                    context.fillText(line, x, y);
                }
                if (posneg == -1) {
                    var metrics2 = context.measureText(line);
                    var testWidth2 = metrics2.width;
                    context.fillText(line, x - testWidth2, y);
                }
                
                line = words[n] + ' ';
                y += lineHeight;
 
            }
            else {
                line = testLine;
            }wraptext_oldsign_old
        }
        //if (lineN == 0) {
        //
        if (posneg == 1) {
            context.fillText(line, x, y);
        }
        if (posneg == -1) {
            metrics2 = context.measureText(line);
            testWidth2 = metrics2.width;
            context.fillText(line, x - testWidth2, y);
        }
        //}
        //context.fillText(line, x, y);


    }

    function wraptext_old(context, text, x, y, maxWidth, lineHeight) {
        var words = text.split(' ');
        var line = '';

        for (var n = 0; n < words.length; n++) {

            var testLine = line + words[n] + ' ';
            var metrics = context.measureText(testLine);
            var testWidth = metrics.width;
            if (testWidth > maxWidth) {

                context.fillText(line, x, y);
                line = words[n] + ' ';
                y += lineHeight;
            }
            else {
                line = testLine;
            }
        }

        context.fillText(line, x, y);

    }

   

    
 