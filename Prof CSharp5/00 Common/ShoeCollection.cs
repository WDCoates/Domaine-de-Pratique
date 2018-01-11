using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleA1._00_Common
{
    class ShoeCollection
    {
        public IEnumerator<string> GetEnumerator()
        {
            yield return "Pump";
            yield return "Ballet";
        }

    }
    class BootCollection
    {
        public IEnumerator<string> GetEnumerator()
        {
            return new Enumerator(0);
        }

        class Enumerator: IEnumerator<string>, IEnumerator, IDisposable
        {
            private int _state;
            private string _current;

            public Enumerator(int state)
            {
                this._state = state;
            }

            public bool MoveNext()
            {
                switch (_state)
                {
                    case 0:
                        _current = "Ankle";
                        _state = 1;
                        return true;
                    case 1:
                        _current = "Calfe";
                        _state = 2;
                        return true;
                    case 2:
                        _current = "Knee";
                        _state = 3;
                        return true;
                    case 3:
                        break;
                }

                return false;
            }

            public string Current
            {
             get { return _current; }   
            }

            object IEnumerator.Current => _current;

            public void Dispose()
            {
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}
