//      __ __    __  __      ____      __  __                
//     / // /   / / / /___  / / /_____/ / / /___  _________ 
//    / // /   / /_/ // _ \/ / // ___/ /_/ // _ \/ ___/ __ \ 
//   / // /   / __  //  __/ / /(__  ) __  //  __/ /  / /_/ / 
//  /_//_/   /_/ /_/ \___/_/_//____/_/ /_/ \___/_/   \____/

if(isPackage(script_delayedSuicide))
    error("ERROR: Script_AntiSuicide - Incompatible add-on is enabled! script_delayedSuicide");
else
    exec("./script_antiSuicide.cs");