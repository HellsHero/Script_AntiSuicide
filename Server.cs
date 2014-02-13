$Server::antiSuicide = 1; //Enable/disable script
$Server::antiSuicide::time = 10; //In seconds
package script_antiSuicide
{
    function serverCmdSuicide(%client)
    {
        if(isObject(%pl = %client.player))
            if(isEventPending(%pl.suicidePrevention) && $Server::antiSuicide)
                return;
            else
                parent::serverCmdSuicide(%client);
    }
    
    function Armor::damage(%this, %obj, %sourceObject, %position, %damage, %damageType)
	{
	    if($Server::antiSuicide)
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