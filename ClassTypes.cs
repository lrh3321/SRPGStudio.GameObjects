using System;

namespace SRPGStudio.GameObjects
{
    [Flags]
    public enum ClassTypes : int
    {
        None = 0,
        /// <summary>步兵</summary>
        Infantry = 1,
        /// <summary>骑兵</summary>
        Cavalry = 2,
        /// <summary>飞兵</summary>
        AirForce = 3,
        /// <summary>重甲</summary>
        Armor = 0x4,
        /// <summary>法师、神官</summary>
        Mage = 0x8,
        /// <summary>龙</summary>
        Dragon = 0x10,
        /// <summary>魔物</summary>
        Monster = 0x20
    }

}