﻿using PillowFight.Repositories.Enumerations;
using PillowFight.Repositories.Interfaces;
using System.Collections.Generic;

namespace PillowFight.Repositories.Models
{
    public class Character : ICharacter
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<StatusEffectEnum> StatusEffects { get; set; }

        public CharacterClassEnum Class { get; set; }

        public int Strength { get; set; }

        public int Dexterity { get; set; }

        public int Constitution { get; set; }

        public int Intelligence { get; set; }

        public int Wisdom { get; set; }

        public int? TorsoSlotItemId { get; set; }

        public IArmorItem TorsoSlotItem { get; set; }

        public int? MainHandSlotItemId { get; set; }

        public IWeaponItem MainHandSlotItem { get; set; }

        //ignoring everything below this so that we arent too bogged down

        public int? ArmsSlotItemId { get; set; }

        public int? HeadSlotItemId { get; set; }

        public int? LegsSlotItemId { get; set; }

        public int? OffHandSlotSlotItemId { get; set; }
    }
}
