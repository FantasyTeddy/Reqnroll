using BoDi;
using Reqnroll.Bindings;

namespace Reqnroll.Plugins
{
    public interface IRuntimePluginTestExecutionLifecycleEventEmitter
    {
        void RaiseExecutionLifecycleEvent(HookType hookType, IObjectContainer container);
    }

    public class RuntimePluginTestExecutionLifecycleEventEmitter : IRuntimePluginTestExecutionLifecycleEventEmitter
    {
        private readonly RuntimePluginTestExecutionLifecycleEvents _events;

        public RuntimePluginTestExecutionLifecycleEventEmitter(RuntimePluginTestExecutionLifecycleEvents events)
        {
            _events = events;
        }

        public void RaiseExecutionLifecycleEvent(HookType hookType, IObjectContainer container)
        {
            switch (hookType)
            {
                case HookType.BeforeTestRun:
                    _events.RaiseBeforeTestRun(container);
                    break;
                case HookType.AfterTestRun:
                    _events.RaiseAfterTestRun(container);
                    break;
                case HookType.BeforeFeature:
                    _events.RaiseBeforeFeature(container);
                    break;
                case HookType.AfterFeature:
                    _events.RaiseAfterFeature(container);
                    break;
                case HookType.BeforeScenario:
                    _events.RaiseBeforeScenario(container);
                    break;
                case HookType.AfterScenario:
                    _events.RaiseAfterScenario(container);
                    break;
                case HookType.BeforeStep:
                    _events.RaiseBeforeStep(container);
                    break;
                case HookType.AfterStep:
                    _events.RaiseAfterStep(container);
                    break;
                default: break;
            }

        }
    }
}
