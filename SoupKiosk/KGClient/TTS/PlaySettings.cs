using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGClient
{
    public class PlaySettings
    {
        /// <summary>
        /// Pitch : 합성음의 높낮이를 지정하며 초기값은 100 범위는 50 ~ 400
        /// </summary>
        public int Pitch
        {
            get { return _Pitch; }
            set
            {
                if (value >= 50 || value <= 400)
                    _Pitch = value;
            }
        }
        private int _Pitch = 103;

        /// <summary>
        /// Speed : 합성음의 속도를 지정하며 초기값은 100 범위는 50 ~ 400
        /// </summary>
        public int Speed
        {
            get { return _Speed; }
            set
            {
                if (value >= 50 || value <= 400)
                    _Speed = value;
            }
        }
        private int _Speed = 100;

        /// <summary>
        /// Volume : 합성음의 음량을 지정하며 초기값은 100 범위는 0 ~ 500
        /// </summary>
        public int Volume
        {
            get { return _Volume; }
            set
            {
                if (value >= 0 && value <= 500)
                    _Volume = value;
            }
        }
        private int _Volume = 400;

        /// <summary>
        /// Pause : 함성음의 문장간 포즈를 지정하며 초기값은 687 범위는 0~65535
        /// </summary>
        public int PauseTime
        {
            get { return _PauseTime; }
            set
            {
                if (value >= 0 || value <= 500)
                    _PauseTime = value;
            }
        }
        private int _PauseTime = 300;
    }
}

