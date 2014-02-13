$Server::antiSuicide = 1; //Enable/disable script
$Server::antiSuicide::time = 10; //In seconds
package script_antiSuicide
{
    function serverCmdSuicide(%client)
    {
        if(isObject(%pl = %client.player))
            if(isEventPending(%pl.suicidePrevention) && $Server::antiSuicide && isObject(%client.minigame))
                return;
            else
                parent::serverCmdSuicide(%client);
    }
    
    function Armor::damage(%this, %obj, %sourceObject, %position, %damage, %damageType)
	{
	    if($Server::antiSuicide && isObject(%client.minigame))
		    %obj.suicidePrevention();
		Parent::damage(%this, %obj, %sourceObject, %position, %damage, %damageType);
	}
};
activatePackage(script_antiSuicide);

function Player::suicidePrevention(%this)
{
    if(isEventPending(%this.suicidePrevention))
		cancel(%this.suicidePrevention);
    %this.suicidePrevention = %this.schedule($Server::antiSuicide::time*1000,suicidePrevention);
}

function serverCmdAntiSuicide(%client,%a)
{
    if(!%client.isAdmin)
        return;
    if(%a $= "" && %b $= "")
    {
        messageClient(%client,'',"\c6Type \c3/antiSuicide A");
        messageClient(%client,'',"\c3A \c6can be replaced with \c3toggle\c6 or a \c3number\c6 which represents seconds");
    }
    else if(%a $= "toggle")
        messageClient(%client,'',"\c6AntiSuicide script is now\c3 " @ (($Server::antiSuicide = !$Server::antiSuicide) ? "enabled" : "disabled"));
    else if(%a > 0)
        messageClient(%client,'',"\c6AntiSuicide time is now\c3 " @ ($Server::antiSuicide::time = %a));
}