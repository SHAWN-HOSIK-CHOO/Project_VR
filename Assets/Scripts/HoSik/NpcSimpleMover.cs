using UnityEngine;

namespace HoSik
{
    public class NpcSimpleMover : SimpleMover
    {
        public override void MoveAttribute()
        {
            base.MoveAttribute();
        }

        void Update()
        {
            MoveAttribute();
        }
    }
}
