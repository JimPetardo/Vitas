#pragma strict

var hasCollided : boolean = false;
 var labelText : String = "";
 
 function OnGUI()
     {
         if (hasCollided ==true)
     {    
          GUI.Box(Rect(140,Screen.height-50,Screen.width-300,120),(labelText));
     }
 }
 
 function OnTriggerEnter(c:Collider)
     {
         if(c.gameObject.tag =="Player") 
     
     {
 
         hasCollided = true;
         labelText = "Hit E to pick up the key!";
         
 }
 }
 
 function OnTriggerExit( other : Collider ){
      hasCollided = false;
  
 }