using System;
using System.Collections.Generic;
using SuperDavis.Interfaces;
using SuperDavis.Factory;

/*
 Class to create a character selector for the user to choose a character.
 @Author Sean Edwards
 */

namespace SuperDavis.Object.Character
{
    class CharacterSelector
    {
        public List<ISprite> CharacterPortraitList = new List<ISprite>();
        private int CharID;
        private int TotalCharacters;

        public CharacterSelector()
        {
            CharID = 0;
            CharacterPortraitList = new List<ISprite>();
            FillList(CharacterPortraitList);
            TotalCharacters = CharacterPortraitList.Count;
        }

        private List<ISprite> FillList(List<ISprite> portraitList)
        {
            portraitList.Add(DavisSpriteFactory.Instance.CreateDavisPortrait());
            portraitList.Add(DavisSpriteFactory.Instance.CreateWoodyPortrait());
            portraitList.Add(DavisSpriteFactory.Instance.CreateBatPortrait());
            return CharacterPortraitList;
        }

        public void NextCharacter()
        {
            if (CharID >= TotalCharacters)
            {
                CharID = 0;
            }
            else
            {
                CharID++;
            }
        }

        public void PreviousCharacter()
        {
            if (CharID < 0)
            {
                CharID = TotalCharacters - 1;
            }
            else
            {
                CharID--;
            }
        }

        public int GetCharacterId()
        {
            return CharID;
        }
    }
}
