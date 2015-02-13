import RAIN.Action

[RAINDecision]
class DecisionTemplate_BOO(RAINDecision): 

	_lastRunning as int = 0

	def Start(ai as RAIN.Core.AI):
		super.Start(ai)

		_lastRunning = 0
		return
	
	def Execute(ai as RAIN.Core.AI):
		tResult as ActionResult = ActionResult.SUCCESS

		while _lastRunning < _children.Count:
			tResult = _children[_lastRunning].Run(ai)
			break unless tResult == ActionResult.SUCCESS
			_lastRunning++

		return tResult;

	def Stop(ai as RAIN.Core.AI):
		super.Stop(ai)
		return