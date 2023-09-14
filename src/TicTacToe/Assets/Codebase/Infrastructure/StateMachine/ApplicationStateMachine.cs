using System;
using System.Collections.Generic;

namespace TicTacToe.Codebase.Infrastructure.StateMachine
{
    public class ApplicationStateMachine : IApplicationStateMachine
    {
        private readonly Dictionary<Type, ApplicationState> _states;
        private readonly DIFactory _diFactory;
        private IState _activeState;

        public ApplicationStateMachine(DIFactory diFactory)
        {
            _diFactory = diFactory;
            
            _states = new Dictionary<Type, ApplicationState>
            {
                [typeof(BootstrapState)] = _diFactory.Create<BootstrapState>().Setup(this),
                [typeof(LoadProgressState)] = _diFactory.Create<LoadProgressState>().Setup(this),
                [typeof(LoadLevelState)] = _diFactory.Create<LoadLevelState>().Setup(this),
                [typeof(GameLoopState)] = _diFactory.Create<GameLoopState>().Setup(this),
            };
        }

        public void Enter<TState>(StateArgs args = null) where TState : ApplicationState
        {
            IState state = ChangeState<TState>();
            state.Enter(args);
        }

        private TState ChangeState<TState>() where TState : ApplicationState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : ApplicationState
        {
            return _states[typeof(TState)] as TState;
        }
    }
}