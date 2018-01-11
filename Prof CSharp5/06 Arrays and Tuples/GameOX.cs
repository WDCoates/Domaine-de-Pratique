using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleA1._06_Arrays_and_Tuples
{
    class GameOX
    {
        private const int MaxTurn = 9;

        private IEnumerator<object> naught;
        private IEnumerator<object> cross;

        public GameOX()
        {
            naught = Naught();
            cross = Cross();
        }

        private int turn = 0;

        public IEnumerator<object> Naught()
        {
            while (true)
            {
                Console.WriteLine($"Naught, turn {turn}");
                if (++turn >= MaxTurn)
                    yield break;
                yield return cross;
            }
        }

        public IEnumerator<object> Cross()
        {
            while (true)
            {
                Console.WriteLine($"Cross, turn {turn}");
                if (++turn >= MaxTurn)
                    yield break;
                yield return naught;
            }
        }
    }
}
