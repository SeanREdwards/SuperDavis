using System;
using System.Collections.Generic;
using SuperDavis.Interfaces;
using SuperDavis.Factory;
/*Class to create a character selector for the user to choose a character.*/
namespace SuperDavis.NewFolder1
{
    class CharacterSelector
    {
        public List<ISprite> CharacterPortraitList = new List<ISprite>();
        private int CharID;
        public CharacterSelector()
        {
            CharID = 0;
            CharacterPortraitList = new List<ISprite>();
            FillList(CharacterPortraitList);
        }

        private List<ISprite> FillList(List<ISprite> portraitList)
        {
            portraitList.Add(DavisSpriteFactory.Instance.CreateDavisPortrait());
            portraitList.Add(DavisSpriteFactory.Instance.CreateWoodyPortrait());
            portraitList.Add(DavisSpriteFactory.Instance.CreateBatPortrait());
            return CharacterPortraitList;
        }
    }
}
