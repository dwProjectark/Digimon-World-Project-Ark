import RAIN.Action;
import RAIN.Core;

@RAINAction
class ActionTemplate_JS extends RAIN.Action.RAINAction
{
    function Start(ai:RAIN.Core.AI):void
	{
        super.Start(ai);
	}

    function Execute(ai:RAIN.Core.AI):ActionResult
	{
        return ActionResult.SUCCESS;
	}

	function Stop(ai:RAIN.Core.AI):void
	{
        super.Stop(ai);
	}
}