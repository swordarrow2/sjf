﻿ 
// Type: Shooting.Planes.Story.Story_SSS03_02B
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting.Planes.Story
{
  internal class Story_SSS03_02B : BaseStory_SSS
  {
    public Story_SSS03_02B(StageDataPackage StageData)
      : base(StageData)
    {
      CharacterR_Touhou characterRTouhou = new CharacterR_Touhou(StageData, "FaceSeiryuu_lo");
      characterRTouhou.TxtureObject2 = this.TextureObjectDictionary[" "];
      characterRTouhou.OriginalPosition = new PointF((float) (this.BoundRect.Width - 60), 380f);
      this.CharR = characterRTouhou;
      CharacterL_Touhou characterLTouhou = new CharacterL_Touhou(StageData, "FaceMarisa_hp2");
      characterLTouhou.TxtureObject2 = this.TextureObjectDictionary[" "];
      characterLTouhou.OriginalPosition = new PointF(70f, 340f);
      this.CharL = characterLTouhou;
      this.SBox = new StoryBox(StageData);
      this.Conv.Add(new Conversation("呜~被打败啦", false, true, "FaceMarisa_hp2", "FaceSeiryuu_lo"));
      this.Conv.Add(new Conversation("好不甘心呀", false, true, (string) null, (string) null));
      this.Conv.Add(new Conversation("那么 你的那份星之碎片就给我保管咯~", true, false, "FaceMarisa_hp2", "FaceSeiryuu_lo"));
      this.Conv.Add(new Conversation("前方侦测到高能量魔力反应 会是什么呢？", true, false, (string) null, (string) null));
      this.Conv.Add(new Conversation("前进前进~", true, false, "FaceMarisa_hp", (string) null));
      this.Conv.Add(new Conversation("小心好奇害死猫哦", false, true, (string) null, "FaceSeiryuu_lo"));
      this.Conv.Add(new Conversation("猫也是有九条命的呢", true, false, "FaceMarisa_hp2", (string) null));
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time != this.Conv.Count)
        return;
      this.SBox.Dispose();
      this.Story = (BaseStory) null;
      EndStage endStage = new EndStage(this.StageData, "St4", false);
      ClearBonus clearBonus = new ClearBonus(this.StageData, 30000000);
    }
  }
}
