import RAIN.Action

[RAINAction]
class ActionTemplate_BOO(RAINAction): 
	def Start(ai as RAIN.Core.AI):
		super.Start(ai)
		return
	
	def Execute(ai as RAIN.Core.AI):
		return ActionResult.SUCCESS

	def Stop(ai as RAIN.Core.AI):
		super.Stop(ai)
		return