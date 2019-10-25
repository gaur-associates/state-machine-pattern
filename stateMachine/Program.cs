using System;
using Stateless;
using Stateless.Graph;

namespace stateMachine
{
    enum Input
    {
        Coin,
        Push
    }
    enum State
    {
        Locked,
        UnLocked
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var stateMachine = new StateMachine<State, Input>(State.Locked);

            stateMachine.Configure(State.Locked)
                .Permit(Input.Coin, State.UnLocked)
                .PermitReentry(Input.Push);

            stateMachine.Configure(State.UnLocked)
                .Permit(Input.Push, State.Locked)
                .PermitReentry(Input.Coin);

            stateMachine.Fire(Input.Coin);
            Console.WriteLine(stateMachine.State);

            string graph = UmlDotGraph.Format(stateMachine.GetInfo());
            Console.WriteLine(graph);


        }
    }
}
