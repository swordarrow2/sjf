﻿// Decompiled with JetBrains decompiler
// Type: Shooting.Boss_Tensei01
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting {
    internal class Boss_Tensei01:BaseBossTouhou {
        public Boss_Tensei01(StageDataPackage StageData)
          : base(StageData) {
            this.TxtureObjects=new TextureObject[3,4]
            {
        {
          this.TextureObjectDictionary["BossTensei-00"],
          this.TextureObjectDictionary["BossTensei-01"],
          this.TextureObjectDictionary["BossTensei-02"],
          this.TextureObjectDictionary["BossTensei-03"]
        },
        {
          this.TextureObjectDictionary["BossTensei-10"],
          this.TextureObjectDictionary["BossTensei-11"],
          this.TextureObjectDictionary["BossTensei-12"],
          this.TextureObjectDictionary["BossTensei-13"]
        },
        {
          this.TextureObjectDictionary["BossTensei-20"],
          this.TextureObjectDictionary["BossTensei-21"],
          this.TextureObjectDictionary["BossTensei-22"],
          this.TextureObjectDictionary["BossTensei-23"]
        }
            };
            this.TxtureObject=this.TxtureObjects[0,0];
            this.OriginalPosition=new PointF((float)(this.BoundRect.Width/2),150f);
            this.DestPoint=(PointF)new Point(this.BoundRect.Width/2,150);
            this.MaxHP=10000;
            this.HealthPoint=(float)this.MaxHP;
            this.Life=6;
            this.Region=20;
            this.Velocity=4f;
            this.DirectionDegree=90.0;
            this.SpellTime=3600;
            this.LifeTime=100000;
            this.OnSpell=false;
            this.SetBossLifeLineTex();
            this.LoadArmon(".\\CS\\St06\\关底Boss\\ctrl.csv");
        }

        public override void Ctrl() {
            base.Ctrl();
            if(Time%3==0) {
                if(MyPlane.StarPoint<0) {
                    MyPlane.StarPoint=0;
                } else if(MyPlane.StarPoint>0&&MyPlane.StarPoint<3000) {
                    MyPlane.StarPoint--;
                } else if(MyPlane.StarPoint>3000) {

                }
            }
            if(!this.OnSpell)
                this.Armon=0.0f;
            switch(this.Life) {
                case 0:
                    this.Velocity=0.0f;
                    this.DestPoint=(PointF)new Point(this.Ran.Next(100,this.BoundRect.Width-100),this.Ran.Next(70,200));
                    break;
                case 1:
                    this.Ctrl1();
                    break;
                case 2:
                    this.Ctrl2();
                    break;
                case 3:
                    this.Ctrl3();
                    break;
                case 4:
                    this.Ctrl4();
                    break;
                case 5:
                    this.Ctrl5();
                    break;
                case 6:
                    this.Ctrl6();
                    break;
            }
            this.MoveToPoint(this.DestPoint);
            if(!this.OnSpell) {
                if((double)this.HealthPoint>=(double)this.SpellcardHP&&this.Time<=this.SpellTime)
                    return;
                this.HealthPoint=(float)this.SpellcardHP;
                this.Time=0;
                this.OnSpell=true;
                ShootingStarShard shootingStarShard = new ShootingStarShard(this.StageData,new PointF((float)(this.BoundRect.Width/2),0.0f));
            } else if((double)this.HealthPoint<=0.0||this.Time>this.SpellTime) {
                --this.Life;
                Rectangle boundRect;
                if((double)this.HealthPoint<=0.0&&this.Life>=-1) {
                    this.GiveItems();
                    StageDataPackage stageData = this.StageData;
                    boundRect=this.BoundRect;
                    PointF OriginalPosition = new PointF((float)(boundRect.Width/2),0.0f);
                    ShootingStarShard shootingStarShard = new ShootingStarShard(stageData,OriginalPosition);
                }
                if(this.Life<=0) {
                    if(this.Life==0) {
                        int x = this.Ran.Next((int)this.OriginalPosition.X-30,(int)this.OriginalPosition.X+30);
                        MyRandom ran = this.Ran;
                        PointF originalPosition = this.OriginalPosition;
                        int minValue = (int)originalPosition.Y+30;
                        originalPosition=this.OriginalPosition;
                        int maxValue = (int)originalPosition.Y+50;
                        int y = ran.Next(minValue,maxValue);
                        this.DestPoint=(PointF)new Point(x,y);
                        this.Velocity=0.5f;
                        BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData,this.OriginalPosition);
                        this.HealthPoint=0.0f;
                        this.GiveEndEffect();
                        this.Life=-1;
                    }
                } else {
                    BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData,this.OriginalPosition);
                    this.StageData.SoundPlay("se_tan00.wav");
                    this.HealthPoint=(float)this.MaxHP;
                    this.Time=0;
                    this.OnSpell=false;
                    boundRect=this.BoundRect;
                    this.DestPoint=(PointF)new Point(boundRect.Width/2,120);
                    this.Velocity=4f;
                }
            }
        }

        public override void GiveEndEffect() {
            this.TransparentValueF=(float)byte.MaxValue;
            Background2DRemover background2Dremover = new Background2DRemover(this.StageData);
            this.Background3D.WarpEnabled=false;
            this.LifeTime=this.Time+150;
            this.Region=0;
            this.StageData.SoundPlay("se_tan01.wav");
            if(this.MyPlane.FscEnabled) {
                this.LifeTime=this.Time+50;
                EndBoss_FSC06 endBossFsC06 = new EndBoss_FSC06(this.StageData,this.OriginalPosition,Color.White,Color.Blue);
            } else {
                this.LifeTime=this.Time+150;
                EndBoss_Touhou06 endBossTouhou06 = new EndBoss_Touhou06(this.StageData,this.OriginalPosition,Color.White,Color.Blue);
            }
        }

        private void Ctrl6() {
            if(!this.OnSpell) {
                this.Armon=this.ArmonArray[0];
                if(this.Time==1) {
                    Background2DRemover background2Dremover = new Background2DRemover(this.StageData);
                    this.DestPoint=(PointF)new Point(this.BoundRect.Width/2,150);
                } else if(this.Time>50)
                    this.RandomMove(346,30,2f,new Rectangle(this.BoundRect.Width/2-60,100,120,40));
                if(this.Time!=60)
                    return;
                string FileName;
                switch(this.Difficulty) {
                    case DifficultLevel.Easy:
                        FileName=".\\CS\\St06\\关底Boss\\1非E.mbg";
                        break;
                    case DifficultLevel.Normal:
                        FileName=".\\CS\\St06\\关底Boss\\1非N.mbg";
                        break;
                    case DifficultLevel.Hard:
                        FileName=".\\CS\\St06\\关底Boss\\1非H.mbg";
                        break;
                    case DifficultLevel.Lunatic:
                        FileName=".\\CS\\St06\\关底Boss\\1非L.mbg";
                        break;
                    default:
                        FileName=".\\CS\\St06\\关底Boss\\1非L.mbg";
                        break;
                }
                new CSEmitterController(this.StageData,this.StageData.LoadCS(FileName)).BossBinding=true;
            } else if(this.Time==1) {
                BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData,this.OriginalPosition);
                SpellCard_SSS06_01 spellCardSsS0601 = new SpellCard_SSS06_01(this.StageData);
            }
        }

        private void Ctrl5() {
            if(!this.OnSpell) {
                this.Armon=this.ArmonArray[2];
                if(this.Time==1) {
                    Background2DRemover background2Dremover = new Background2DRemover(this.StageData);
                    this.DestPoint=(PointF)new Point(this.BoundRect.Width/2,150);
                } else if(this.Time>50)
                    this.RandomMove(346,30,2f,new Rectangle(this.BoundRect.Width/2-60,100,120,40));
                if(this.Time!=60)
                    return;
                string FileName;
                switch(this.Difficulty) {
                    case DifficultLevel.Easy:
                        FileName=".\\CS\\St06\\关底Boss\\2非E.mbg";
                        break;
                    case DifficultLevel.Normal:
                        FileName=".\\CS\\St06\\关底Boss\\2非N.mbg";
                        break;
                    case DifficultLevel.Hard:
                        FileName=".\\CS\\St06\\关底Boss\\2非H.mbg";
                        break;
                    case DifficultLevel.Lunatic:
                        FileName=".\\CS\\St06\\关底Boss\\2非L.mbg";
                        break;
                    default:
                        FileName=".\\CS\\St06\\关底Boss\\2非L.mbg";
                        break;
                }
                new CSEmitterController(this.StageData,this.StageData.LoadCS(FileName)).BossBinding=true;
            } else if(this.Time==1) {
                BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData,this.OriginalPosition);
                SpellCard_SSS06_02 spellCardSsS0602 = new SpellCard_SSS06_02(this.StageData);
            }
        }

        private void Ctrl4() {
            if(!this.OnSpell) {
                this.Armon=this.ArmonArray[4];
                if(this.Time==1) {
                    Background2DRemover background2Dremover = new Background2DRemover(this.StageData);
                    this.DestPoint=(PointF)new Point(this.BoundRect.Width/2,150);
                } else if(this.Time>150)
                    this.RandomMove(346,30,2f,new Rectangle(this.BoundRect.Width/2-60,100,120,40));
                if(this.Time!=160)
                    return;
                string FileName;
                switch(this.Difficulty) {
                    case DifficultLevel.Easy:
                        FileName=".\\CS\\St06\\关底Boss\\3非E.mbg";
                        break;
                    case DifficultLevel.Normal:
                        FileName=".\\CS\\St06\\关底Boss\\3非N.mbg";
                        break;
                    case DifficultLevel.Hard:
                        FileName=".\\CS\\St06\\关底Boss\\3非H.mbg";
                        break;
                    case DifficultLevel.Lunatic:
                        FileName=".\\CS\\St06\\关底Boss\\3非L.mbg";
                        break;
                    default:
                        FileName=".\\CS\\St06\\关底Boss\\3非L.mbg";
                        break;
                }
                new CSEmitterController(this.StageData,this.StageData.LoadCS(FileName)).BossBinding=true;
            } else if(this.Time==1) {
                BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData,this.OriginalPosition);
                SpellCard_SSS06_03 spellCardSsS0603 = new SpellCard_SSS06_03(this.StageData);
            }
        }

        private void Ctrl3() {
            if(!this.OnSpell) {
                this.Armon=this.ArmonArray[6];
                if(this.Time==1) {
                    Background2DRemover background2Dremover = new Background2DRemover(this.StageData);
                    this.DestPoint=(PointF)new Point(this.BoundRect.Width/2,150);
                } else if(this.Time>50)
                    this.RandomMove(346,30,2f,new Rectangle(this.BoundRect.Width/2-60,100,120,40));
                if(this.Time==60) {
                    TenseiWing tenseiWing = new TenseiWing(this.StageData);
                    this.StageData.VibrateStart(90);
                }
                if(this.Time!=150)
                    return;
                string FileName;
                switch(this.Difficulty) {
                    case DifficultLevel.Easy:
                        FileName=".\\CS\\St06\\关底Boss\\4非E.mbg";
                        break;
                    case DifficultLevel.Normal:
                        FileName=".\\CS\\St06\\关底Boss\\4非N.mbg";
                        break;
                    case DifficultLevel.Hard:
                        FileName=".\\CS\\St06\\关底Boss\\4非H.mbg";
                        break;
                    case DifficultLevel.Lunatic:
                        FileName=".\\CS\\St06\\关底Boss\\4非L.mbg";
                        break;
                    default:
                        FileName=".\\CS\\St06\\关底Boss\\4非L.mbg";
                        break;
                }
                new CSEmitterController(this.StageData,this.StageData.LoadCS(FileName)).BossBinding=true;
            } else if(this.Time==1) {
                BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData,this.OriginalPosition);
                SpellCard_SSS06_04 spellCardSsS0604 = new SpellCard_SSS06_04(this.StageData);
            }
        }

        private void Ctrl2() {
            if(!this.OnSpell) {
                if(this.Time==1) {
                    Background2DRemover background2Dremover = new Background2DRemover(this.StageData);
                    this.DestPoint=(PointF)new Point(this.BoundRect.Width/2,150);
                }
                if(this.Time!=100)
                    return;
                this.OnSpell=true;
            } else if(this.Time==101) {
                BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData,this.OriginalPosition);
                SpellCard_SSS06_05 spellCardSsS0605 = new SpellCard_SSS06_05(this.StageData);
            }
        }

        private void Ctrl1() {
            if(!this.OnSpell) {
                if(this.Time==1) {
                    Background2DRemover background2Dremover = new Background2DRemover(this.StageData);
                    this.DestPoint=(PointF)new Point(this.BoundRect.Width/2,150);
                }
                if(this.Time!=100)
                    return;
                this.OnSpell=true;
                this.SpellTime=7200;
            } else if(this.Time==101) {
                BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData,this.OriginalPosition);
                SpellCard_SSS06_06 spellCardSsS0606 = new SpellCard_SSS06_06(this.StageData);
            }
        }
    }
}
