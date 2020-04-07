using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;

 namespace LawMate.Workflow
{
    [DefaultPropertyAttribute("Workflow_Step_Description_Qualifier_Eng")]
    public class Activity : Step
    {
        
        public Activity(Diagram d, lmDatasets.ActivityConfig.ACSeriesRow acsr)
        {
            myDiagram = d;
            myACS = acsr;
            mySize = new Size(d.DefaultStepWidth, d.DefaultStepHeight);
        }

        public override void Refresh()
        {

            string StepText = UIHelper.AtMng.acMng.GetACSeries().GetRecordedStepText(myACS);

            Brush BrushShadow = myDiagram.BrushSemiTrans;
            SolidBrush drawBrush = new SolidBrush(Color.White);
            Pen PenDraw = myDiagram.PenSteelBlue;

            if (myACS.Obsolete)
            {
                BrushShadow = Brushes.IndianRed;
                drawBrush = new SolidBrush(Color.LightGray);
            }

            if (IsSelected)
            {
                BrushShadow = myDiagram.BrushSelected;
                PenDraw = Pens.Firebrick; 
            }
            
            if (!myACS.IsRoleCodeNull())
            {
                System.Data.DataTable dtRole = UIHelper.AtMng.GetFile().Codes("RoleCode");
                System.Data.DataRow[] drRole = dtRole.Select("RoleCode='" + myACS.RoleCode + "'", "");
                if (drRole.Length == 0)
                {
                    dtRole = UIHelper.AtMng.GetFile().Codes("ContactType");
                    drRole = dtRole.Select("ContactTypeCode='" + myACS.RoleCode + "'", "");
                }
                if (!drRole[0].IsNull("WFBGColor"))
                {
                    int intBrushColor = (int)drRole[0]["WFBGColor"];
                    if (intBrushColor != 0)
                    {
                        Color BrushColor = Color.FromArgb(intBrushColor);
                        drawBrush = new SolidBrush(BrushColor);
                    }
                }
            }

            //calculate leftside top box size
            SizeF StepCodeBoxSize = myDiagram.drawingSurface.MeasureString(myACS.StepCode, myDiagram.SelectedFont);
            Rectangle topRectangle = new Rectangle(myRectangle.Left, myRectangle.Top - 18, (int)StepCodeBoxSize.Width + 20, 18);

            if (!IsSelected)
            {
                //offset rectangles to draw shadow
                myRectangle.Inflate(myDiagram.recInflate+1, myDiagram.recInflate+1);
                topRectangle.Inflate(myDiagram.recInflate+1, myDiagram.recInflate+1);
                myDiagram.drawingSurface.FillRectangle(myDiagram.BrushDrawingSurface, myRectangle);
                myDiagram.drawingSurface.FillRectangle(myDiagram.BrushDrawingSurface, topRectangle);
                myRectangle.Inflate((myDiagram.recInflate+1) * -1, (myDiagram.recInflate+1) * -1);
                topRectangle.Inflate((myDiagram.recInflate +1)* -1, (myDiagram.recInflate+1) * -1);


                myRectangle.Offset(myDiagram.recOffset, myDiagram.recOffset);
                topRectangle.Offset(myDiagram.recOffset, myDiagram.recOffset);
                myDiagram.drawingSurface.FillRectangle(BrushShadow, myRectangle);
                myDiagram.drawingSurface.FillRectangle(BrushShadow, topRectangle);
                myRectangle.Offset(myDiagram.recOffset * -1, myDiagram.recOffset * -1);
                topRectangle.Offset(myDiagram.recOffset * -1, myDiagram.recOffset * -1);
            }
            else
            {
                //offset rectangles to draw shadow
                myRectangle.Inflate(myDiagram.recInflate, myDiagram.recInflate);
                topRectangle.Inflate(myDiagram.recInflate, myDiagram.recInflate);
                myDiagram.drawingSurface.FillRectangle(BrushShadow, myRectangle);
                myDiagram.drawingSurface.FillRectangle(BrushShadow, topRectangle);
                myRectangle.Inflate(myDiagram.recInflate * -1, myDiagram.recInflate * -1);
                topRectangle.Inflate(myDiagram.recInflate * -1, myDiagram.recInflate * -1);
            }


           
            if (myACS.SeriesId != myDiagram.mySeries.SeriesId) //step drawn in from different workflow due to connector
            {
                myDiagram.drawingSurface.DrawRectangle(myDiagram.PenWhite, myRectangle);
                if (myACS.ActivityCodeRow != null)
                {
                    myDiagram.drawingSurface.DrawRectangle(myDiagram.PenWhite, topRectangle);
                    myDiagram.drawingSurface.FillRectangle(myDiagram.BrushNotInSeries, topRectangle.Left, topRectangle.Top, topRectangle.Width, topRectangle.Height + 1);
                    myDiagram.drawingSurface.FillRectangle(myDiagram.BrushNotInSeries, myRectangle);

                    myDiagram.drawingSurface.DrawImage(Properties.Resources.act, myRectangle.Left + 1, myRectangle.Top - 17);
                    myDiagram.drawingSurface.DrawString(myACS.StepCode, myDiagram.FontUnderlineBold, myDiagram.BrushBlue, myRectangle.Left + 18, myRectangle.Top - 16);
                    myDiagram.drawingSurface.DrawString(StepText, myDiagram.SelectedFont, myDiagram.BrushWhite, myRectangle);
                }
            }
            else 
            {
                myDiagram.drawingSurface.DrawRectangle(PenDraw, myRectangle);
                myDiagram.drawingSurface.DrawRectangle(PenDraw, topRectangle);

                if (myACS.ActivityCodeRow != null)
                {
                    myDiagram.drawingSurface.FillRectangle(drawBrush, topRectangle.Left, topRectangle.Top, topRectangle.Width, topRectangle.Height + 1);
                    myDiagram.drawingSurface.FillRectangle(drawBrush, myRectangle);

                    myDiagram.drawingSurface.DrawImage(Properties.Resources.act, myRectangle.Left + 1, myRectangle.Top - 17);
                    myDiagram.drawingSurface.DrawString(myACS.StepCode, myDiagram.FontUnderlineBold, myDiagram.BrushBlue, myRectangle.Left + 18, myRectangle.Top - 16);
                    myDiagram.drawingSurface.DrawString(StepText, myDiagram.DrawFont, myDiagram.BrushBlack, myRectangle);
                }
            }

            int iconTopCount = 0;
            int iconBottomCount = 0;
            int iconSpacing=20;
            int sLeft = myRectangle.Left + (int)StepCodeBoxSize.Width + 6;
            int sTop = myRectangle.Top - 18;
            int sBottom = myRectangle.Bottom - 17;

            if (myACS.RowState == System.Data.DataRowState.Modified)
            {
               Rectangle modRectangle = new Rectangle(myRectangle.Left-18, myRectangle.Top - 18, 18, 18);
               myDiagram.drawingSurface.FillRectangle(myDiagram.BrushSelected, modRectangle);
               myDiagram.drawingSurface.DrawImage(Properties.Resources.edit3, myRectangle.Left-17, myRectangle.Top - 17);
            }

            if (myACS.PauseParent)
            {
                iconTopCount++;
                myDiagram.drawingSurface.DrawImage(Properties.Resources.pause1, sLeft + (iconTopCount * iconSpacing), sTop);

            }
            if (myACS.StopParent)
            {
                iconTopCount++;
                myDiagram.drawingSurface.DrawImage(Properties.Resources.StopCancel, sLeft + (iconTopCount * iconSpacing), sTop);
            }

            if (myACS.StartParent)
            {
                iconTopCount++;
                myDiagram.drawingSurface.DrawImage(Properties.Resources.Next, sLeft + (iconTopCount * iconSpacing), sTop);
            }
            
            if (!myACS.IsHelpENull() || !myACS.IsHelpFNull())
            {
                iconTopCount++;
                myDiagram.drawingSurface.DrawImage(Properties.Resources.help, sLeft + (iconTopCount * iconSpacing), sTop-2);
            }

            if (myACS.AutoChain)
            {
                iconTopCount++;
                myDiagram.drawingSurface.DrawImage(Properties.Resources.autochain, sLeft + (iconTopCount * iconSpacing), sTop);
            }

            if (myACS.NoResurface)
            {
                myDiagram.drawingSurface.DrawImage(Properties.Resources.noaccess, myRectangle.Right - 16, myRectangle.Top + (myRectangle.Height/2)-8);
            }


            if (!myACS.OnceOnly)
            {
                iconTopCount++;
                myDiagram.drawingSurface.DrawImage(Properties.Resources.notOnceOnly,  sLeft + (iconTopCount * iconSpacing), sTop);
            }

            if (!myACS.IsRoleCodeNull())
            {
                iconBottomCount++;
                myDiagram.drawingSurface.DrawImage(Properties.Resources.roles, myRectangle.Left - 16 + (iconBottomCount * iconSpacing), sBottom);

            }

            if (myACS.ShowSkipDoc)
            {
                iconBottomCount++;
                myDiagram.drawingSurface.DrawImage(Properties.Resources.skipdocument, myRectangle.Left - 16 + (iconBottomCount * iconSpacing), sBottom);
            }

            if (myACS.ActivityCodeRow.Communication)
            {
                iconBottomCount++;
                myDiagram.drawingSurface.DrawImage(Properties.Resources.mail5, myRectangle.Left - 16 + (iconBottomCount * iconSpacing), sBottom);

            }

            if (!myACS.IsCaseStatusIdNull())
            {
                iconBottomCount++;
                myDiagram.drawingSurface.DrawImage(Properties.Resources.reports, myRectangle.Left - 16 + (iconBottomCount * iconSpacing), sBottom);

            }

            if (myACS.GetActivityFieldRows().Length > 0)
            {
                iconBottomCount++;
                bool hasDoc = false;
                bool hasADMS = false;
                bool hasXfer = false;
                myDiagram.drawingSurface.DrawImage(Properties.Resources.metadata, myRectangle.Left-16 + (iconBottomCount * iconSpacing), sBottom);
                foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in myACS.GetActivityFieldRows())
                {
                    if (!afr.IsNull("ObjectName"))
                    {
                        switch (afr.ObjectName)
                        {
                            case "Document":
                                if (!hasDoc)
                                {
                                    iconBottomCount++;
                                    myDiagram.drawingSurface.DrawImageUnscaled(Properties.Resources.paper, myRectangle.Left - 16 + (iconBottomCount * iconSpacing), sBottom);
                                }
                                hasDoc = true;
                                break;
                            case "ADMSLookup":
                            case "ADMSEAppeal":
                            case "ADMSEDecision":
                            case "ADMSEIssues":
                            case "ADMSEParticipant":
                                if (!hasADMS)
                                {
                                    iconBottomCount++;
                                    myDiagram.drawingSurface.DrawImage(Properties.Resources.SystemDefaults, myRectangle.Left - 16 + (iconBottomCount * iconSpacing), sBottom);
                                }
                                hasADMS = true;
                                break;
                            case "DocTransfer":

                                if (!hasXfer)
                                {
                                    iconBottomCount++;
                                    myDiagram.drawingSurface.DrawImage(Properties.Resources.moveFolder, myRectangle.Left - 16 + (iconBottomCount * iconSpacing), sBottom);
                                }
                                hasXfer = true;
                                break;
                        }
                        
                    }
   
                }
            }
                
                
        }

        public override void Draw(Point p)
        {
            myRectangle = new Rectangle(p, mySize);
            Refresh();
        }

        public override bool HitTest(System.Drawing.Point p)
        {
            return myRectangle.Contains(p);
        }

        //Public Properties


        [DescriptionAttribute("The code for the inherited step template."),
     CategoryAttribute("1. Inherited Template Step"),]
        public virtual string Template_Step_Code
        {
            get { return myACS.ActivityCodeRow.ActivityCode; }
        }

        [DescriptionAttribute("The english description for the inherited step template."),
     CategoryAttribute("1. Inherited Template Step")]
        public virtual string Template_Step_Description_Eng
        {
            get { return myACS.ActivityCodeRow.ActivityNameEng; }
        }

        [DescriptionAttribute("The french description for the inherited step template."),
     CategoryAttribute("1. Inherited Template Step")]
        public virtual string Template_Step_Description_Fre
        {
            get { return myACS.ActivityCodeRow.ActivityNameFre; }
        }

        [DescriptionAttribute("The english past tense description for the inherited step template."),
     CategoryAttribute("1. Inherited Template Step")]
        public virtual string Template_Step_Past_Tense_Description_Eng
        {
            get { return myACS.ActivityCodeRow.ActivityNamePastTenseEng; }
        }

        [DescriptionAttribute("The french past tense description for the inherited step template."),
     CategoryAttribute("1. Inherited Template Step")]
        public virtual string Template_Step_Past_Tense_Description_Fre
        {
            get { return myACS.ActivityCodeRow.ActivityNamePastTenseFre; }
        }

        [DescriptionAttribute("The object (table) that contains the field which will receive the activity date."),
     CategoryAttribute("1. Inherited Template Step")]
        public virtual string Associated_Object
        {
            get { return myACS.ActivityCodeRow.IsAssociatedObjectNull() ? "" : myACS.ActivityCodeRow.AssociatedObject; }
            //set
            //{
            //    if (myACS.ActivityCodeRow.AssociatedObject == "")
            //        myACS.ActivityCodeRow.SetAssociatedObjectNull();
            //    else
            //        myACS.ActivityCodeRow.AssociatedObject = value;
            //}
        }

        [DescriptionAttribute("The field that will receive the activity date as its value."),
     CategoryAttribute("1. Inherited Template Step")]
        public virtual string Associated_Field
        {
            get { return myACS.ActivityCodeRow.IsAssociatedFieldNull() ? "" : myACS.ActivityCodeRow.AssociatedField; }
        }

        [DescriptionAttribute("Inidicates whether the activity is of type communication."),
     CategoryAttribute("1. Inherited Template Step"),
        DefaultValueAttribute(false)]
        public virtual bool Contains_Document
        {
            get { return myACS.ActivityCodeRow.Communication; }
            // set { myACS.ActivityCodeRow.Communication = value; }
        }

        [DescriptionAttribute("Indicates whether to skip the related fields in the Activity Wizard."),
     CategoryAttribute("1. Inherited Template Step"),
        DefaultValueAttribute(false)]
        public virtual bool Skip_Related_Fields
        {
            get { return myACS.ActivityCodeRow.SkipRelatedFields; }
            // set { myACS.ActivityCodeRow.SkipRelatedFields = value; }
        }

        [DescriptionAttribute("Indicates whether the disbursement tab will show in the Activity Wizard."),
     CategoryAttribute("1. Inherited Template Step"),
        DefaultValueAttribute(false)]
        public virtual bool Go_To_Disbursements
        {
            get { return myACS.ActivityCodeRow.GoToDisbursements; }
            //  set { myACS.ActivityCodeRow.GoToDisbursements = value; }
        }

        [DescriptionAttribute("Indicates whether the instance of this activity code is read-only."),
     CategoryAttribute("1. Inherited Template Step"),
        DefaultValueAttribute(false),
       BrowsableAttribute(false)]
        public virtual bool Read_Only
        {
            get { return myACS.ActivityCodeRow.ReadOnly; }
            //   set { myACS.ActivityCodeRow.GoToDisbursements = value; }
        }

        [DescriptionAttribute("Indicates whether this activity is obsolete.  The activity no longer appears as available in the application.  Existing instances of the activity still remain."),
     CategoryAttribute("1. Inherited Template Step"),
        DefaultValueAttribute(false),
       BrowsableAttribute(false)]
        public virtual bool AC_Obsolete
        {
            get { return myACS.ActivityCodeRow.Obsolete; }
            //  set { myACS.ActivityCodeRow.Obsolete = value; }
        }


        [DescriptionAttribute("Workflow Step Icon"),
      CategoryAttribute("2. Workflow Step Description")]
        public virtual string Workflow_Step_Icon
        {
            get { return myACS.IsIconResourceNull() ? "" : myACS.IconResource; }
            /*set
            {
                if (value== "")
                    myACS.SetIconResourceNull();
                else
                    myACS.IconResource = value;
            }*/
        }

        [DescriptionAttribute("Workflow Step Code"),
        CategoryAttribute("2. Workflow Step Description")]
        public virtual string Workflow_Step_Code
        {
            get { return myACS.StepCode; }
            set 
            {
                //if (value== "")
                //    myACS.SetSuffixNull();
                //else
                    myACS.StepCode= value; 
            }
        }

        [DescriptionAttribute("The english description qualifier for the workflow step."),
     CategoryAttribute("2. Workflow Step Description")]
        public virtual string Workflow_Step_Description_Qualifier_Eng
        {
            get { return myACS.IsDescEngNull() ? "" : myACS.DescEng; }
            set 
            {
                if (value== "")
                    myACS.SetDescEngNull();
                else
                    myACS.DescEng= value; 
            }
        }

        [DescriptionAttribute("The french description qualifier for the workflow step."),
      CategoryAttribute("2. Workflow Step Description")]
        public virtual string Workflow_Step_Description_Qualifier_Fre
        {
            get { return myACS.IsDescFreNull() ? "" : myACS.DescFre; }
            set 
            {
                if (value == "")
                    myACS.SetDescFreNull();
                else
                    myACS.DescFre= value; 
            }
        }

        [DescriptionAttribute("The english past tense description qualifier for the workflow step."),
    CategoryAttribute("2. Workflow Step Description")]
        public virtual string Workflow_Step_PastTense_Description_Qualifier_Eng
        {
            get { return myACS.IsDescPastTenseEngNull() ? "" : myACS.DescPastTenseEng; }
            set
            {
                if (value == "")
                    myACS.SetDescPastTenseEngNull();
                else
                    myACS.DescPastTenseEng = value;
            }
        }

        [DescriptionAttribute("The french past tense description qualifier for the workflow step."),
      CategoryAttribute("2. Workflow Step Description")]
        public virtual string Workflow_Step_PastTense_Description_Qualifier_Fre
        {
            get { return myACS.IsDescPastTenseFreNull() ? "" : myACS.DescPastTenseFre; }
            set
            {
                if (value == "")
                    myACS.SetDescPastTenseFreNull();
                else
                    myACS.DescPastTenseFre = value;
            }
        }

        [DescriptionAttribute("The type of step."),
        CategoryAttribute("3. Workflow Step Properties")]
        public virtual atriumBE.StepType Step_Type
        {
            get { return (atriumBE.StepType)myACS.StepType; }
        }

        [DescriptionAttribute("The initial section to start on in the Activity Wizard."),
      CategoryAttribute("3. Workflow Step Properties")]
        public virtual atriumBE.Step Initial_Wizard_Section
        {
            get { return (atriumBE.Step)myACS.InitialStep; }
            set { myACS.InitialStep = (int)value; }
        }

        [DescriptionAttribute("Indicates whether the wizard is automatically relaunched after this step."),
CategoryAttribute("3. Workflow Step Properties")]
        public virtual bool AutoChain
        {
            set { myACS.AutoChain = value; }
            get { return myACS.AutoChain; }
        }

        [DescriptionAttribute("Indicates whether the process ends, or whether it pops back out into its parent process."),
CategoryAttribute("3. Workflow Step Properties")]
        public virtual bool NoResurface
        {
            set { myACS.NoResurface = value; }
            get { return myACS.NoResurface; }
        }

        [DescriptionAttribute("Indicates whether the parent process gets paused when this step is performed."),
CategoryAttribute("3. Workflow Step Properties")]
        public virtual bool PauseParent
        {
            set { myACS.PauseParent = value; }
            get { return myACS.PauseParent; }
        }
        [DescriptionAttribute("Indicates whether the parent process gets re-started when this step is performed."),
CategoryAttribute("3. Workflow Step Properties")]
        public virtual bool StartParent
        {
            set { myACS.StartParent = value; }
            get { return myACS.StartParent; }
        }
        [DescriptionAttribute("Indicates whether the parent process gets terminated when this step is performed."),
CategoryAttribute("3. Workflow Step Properties")]
        public virtual bool StopParent
        {
            set { myACS.StopParent = value; }
            get { return myACS.StopParent; }
        }
        [DescriptionAttribute("Indicates whether the workflow step is a starting point in a process."),
      CategoryAttribute("3. Workflow Step Properties")]
        public virtual bool Start
        {
            get { return myACS.Start; }
        }

        [DescriptionAttribute("Indicates whether the workflow step is a finishing point in a process."),
     CategoryAttribute("3. Workflow Step Properties")]
        public virtual bool Finish
        {
            get { return myACS.Finish; }
        }

        [DescriptionAttribute("Indicates whether the workflow step can be entered by the owner office."),
     CategoryAttribute("3. Workflow Step Properties")]
        public virtual bool For_Owner
        {
            get { return myACS.ForOwner; }
            set { myACS.ForOwner = value; }
        }

        [DescriptionAttribute(""),
CategoryAttribute("3. Workflow Step Properties")]
        public virtual bool Show_BF
        {
            get { return myACS.ShowBF; }
            set { myACS.ShowBF = value; }
        }

        [DescriptionAttribute(""),
CategoryAttribute("3. Workflow Step Properties")]
        public virtual bool Has_Billing
        {
            get { return myACS.HasBilling; }
            set { myACS.HasBilling = value; }
        }

        [DescriptionAttribute(""),
CategoryAttribute("3. Workflow Step Properties")]
        public virtual bool Show_Disb
        {
            get { return myACS.ShowDisb; }
            set { myACS.ShowDisb = value; }
        }

        [DescriptionAttribute(""),
CategoryAttribute("3. Workflow Step Properties")]
        public virtual bool Show_Skip_Doc
        {
            get { return myACS.ShowSkipDoc; }
            set { myACS.ShowSkipDoc = value; }
        }

        [DescriptionAttribute("Indicates whether the workflow step can be entered by the lead office."),
     CategoryAttribute("3. Workflow Step Properties")]
        public virtual bool For_Lead
        {
            get { return myACS.ForLead; }
            set { myACS.ForLead = value; }
        }

        [DescriptionAttribute("Indicates whether the workflow step can be entered by an office who is not the lead or owner (previous office/temporary access office)."),
     CategoryAttribute("3. Workflow Step Properties")]
        public virtual bool For_Agent
        {
            get { return myACS.ForAgent; }
            set { myACS.ForAgent = value; }
        }

        [DescriptionAttribute("Indicates whether the workflow step can be entered by the client."),
     CategoryAttribute("3. Workflow Step Properties")]
        public virtual bool For_Client
        {
            get { return myACS.ForClient; }
            set { myACS.ForClient = value; }
        }

        [DescriptionAttribute("Indicates whether the workflow step can only be entered once for the entirety of the process."),
      CategoryAttribute("3. Workflow Step Properties")]
        public virtual bool Once_Only
        {
            get { return myACS.OnceOnly; }
            set { myACS.OnceOnly = value; }
        }

        [DescriptionAttribute("Number used to sequence (default sort) the workflow steps in the workflow steps grid panel."),
      CategoryAttribute("3. Workflow Step Properties")]
        public virtual int Sequence
        {
            get { return  myACS.Seq; }
            //set { myACS.Seq = value; }
        }

        [DescriptionAttribute("Indicates whether the workflow step is obsolete (i.e. it cannot be deleted from the process as activities exist based in its model, and it must be hidden as a possible path in the actual execution of the process.)"),
     CategoryAttribute("3. Workflow Step Properties")]
        public virtual bool Obsolete
        {
            get { return myACS.Obsolete; }
            set { myACS.Obsolete = value; }
        }

        [TypeConverter(typeof(RoleCodeConverter)), DescriptionAttribute("Role (Actor) that can perform the workflow step."),
      CategoryAttribute("3. Workflow Step Properties")]
        public virtual string Role
        {
            get
            {
                if (RoleCodeConverter.roles.Count == 0)
                    return null;
                if (!myACS.IsRoleCodeNull())
                    return RoleCodeConverter.roles[myACS.RoleCode];
                else
                    return null;
            }
            set
            {
                if (value == null ||value=="")
                    myACS.SetRoleCodeNull();
                else
                    myACS.RoleCode = RoleCodeConverter.rolesV[value];
            }
        }

        [DescriptionAttribute("Path to the english help section associated with this workflow step."),
              CategoryAttribute("4. Workflow Step Help")]
        public virtual string Help_Eng
        {
            get { return myACS.IsHelpENull() ? "" : myACS.HelpE; }
            set 
            {
                if (value== "")
                    myACS.SetHelpENull();
                else
                    myACS.HelpE= value; 
            }
        }

        [DescriptionAttribute("Path to the french help section associated with this workflow step."),
      CategoryAttribute("4. Workflow Step Help")]
        public virtual string Help_Fre
        {
            get { return myACS.IsHelpFNull() ? "": myACS.HelpF; }
            set 
            {
                if (value == "")
                    myACS.SetHelpFNull();
                else
                    myACS.HelpF = value; 
            }
        }

        [DescriptionAttribute("English text for the Activity Info Section"),
              CategoryAttribute("5. Activity Wizard Info Text")]
        public virtual string Activity_Info_Eng
        {
            get { return myACS.IsACInfoENull() ? "": myACS.ACInfoE; }
            set 
            {
                if (value == "")
                    myACS.SetACInfoENull();
                else
                    myACS.ACInfoE = value; 
            }
        }

        [DescriptionAttribute("French text for the Activity Info Section"),
             CategoryAttribute("5. Activity Wizard Info Text")]
        public virtual string Activity_Info_Fre
        {
            get { return myACS.IsACInfoFNull() ? "": myACS.ACInfoF; }
            set 
            {
                if (value == "")
                    myACS.SetACInfoFNull();
                else
                    myACS.ACInfoF = value; 
            }
        }

        [DescriptionAttribute("English text for the BF Section"),
              CategoryAttribute("5. Activity Wizard Info Text")]
        public virtual string BF_Eng
        {
            get { return myACS.IsBFENull() ? "": myACS.BFE; }
            set 
            {
                if (value == "")
                    myACS.SetBFENull();
                else
                    myACS.BFE = value; 
            }
        }

        [DescriptionAttribute("French text for the BF Section"),
             CategoryAttribute("5. Activity Wizard Info Text")]
        public virtual string BF_Fre
        {
            get { return myACS.IsBFFNull() ? "": myACS.BFF; }
            set 
            {
                if (value == "")
                    myACS.SetBFFNull();
                else
                    myACS.BFF = value; 
            }
        }

        [DescriptionAttribute("English text for the Timekeeping/Billing Section"),
             CategoryAttribute("5. Activity Wizard Info Text")]
        public virtual string Billing_Eng
        {
            get { return myACS.IsBillingENull() ? "": myACS.BillingE; }
            set 
            {
                if (value == "")
                    myACS.SetBillingENull();
                else
                    myACS.BillingE = value; 
            }
        }

        [DescriptionAttribute("French text for the Timekeeping/Billing Section"),
             CategoryAttribute("5. Activity Wizard Info Text")]
        public virtual string Billing_Fre
        {
            get { return myACS.IsBillingFNull() ? "": myACS.BillingF; }
            set 
            {
                if (value == "")
                    myACS.SetBillingFNull();
                else
                    myACS.BillingF = value; 
            }
        }

        [DescriptionAttribute("English text for the Confirmation Section"),
            CategoryAttribute("5. Activity Wizard Info Text")]
        public virtual string Confirmation_Eng
        {
            get { return myACS.IsConfirmENull() ? "": myACS.ConfirmE; }
            set 
            {
                if (value == "")
                    myACS.SetConfirmENull();
                else
                    myACS.ConfirmE = value; 
            }
        }

        [DescriptionAttribute("French text for the Confirmation Section"),
             CategoryAttribute("5. Activity Wizard Info Text")]
        public virtual string Confirmation_Fre
        {
            get { return myACS.IsConfirmFNull() ? "" : myACS.ConfirmF; }
            set
            {
                if (value == "")
                    myACS.SetConfirmFNull();
                else
                    myACS.ConfirmF = value;
            }
        }

        [DescriptionAttribute("English text for the Disbursement Section"),
            CategoryAttribute("5. Activity Wizard Info Text")]
        public virtual string Disbursement_Eng
        {
            get { return myACS.IsDisbENull() ? "": myACS.DisbE; }
            set 
            {
                if (value == "")
                    myACS.SetDisbENull();
                else
                    myACS.DisbE = value; 
            }
        }

        [DescriptionAttribute("French text for the Disbursement Section"),
             CategoryAttribute("5. Activity Wizard Info Text")]
        public virtual string Disbursement_Fre
        {
            get { return myACS.IsDisbFNull() ? "" : myACS.DisbF; }
            set
            {
                if (value == "")
                    myACS.SetDisbFNull();
                else
                    myACS.DisbF = value;
            }
        }

        [DescriptionAttribute("English text for the Document Section"),
           CategoryAttribute("5. Activity Wizard Info Text")]
        public virtual string Document_Eng
        {
            get { return myACS.IsDocumentENull() ? "": myACS.DocumentE; }
            set 
            {
                if (value == "")
                    myACS.SetDocumentENull();
                else
                    myACS.DocumentE = value; 
            }
        }

        [DescriptionAttribute("French text for the Document Section"),
             CategoryAttribute("5. Activity Wizard Info Text")]
        public virtual string Document_Fre
        {
            get { return myACS.IsDocumentFNull() ? "": myACS.DocumentF; }
            set 
            {
                if (value == "")
                    myACS.SetDocumentFNull();
                else
                    myACS.DocumentF = value; 
            }
        }

        [DescriptionAttribute("English text for the Prompt Section"),
           CategoryAttribute("5. Activity Wizard Info Text")]
        public virtual string Prompt_Eng
        {
            get { return myACS.IsPromptENull() ? "": myACS.PromptE; }
            set 
            {
                if (value == "")
                    myACS.SetPromptENull();
                else
                    myACS.PromptE = value; 
            }
        }

        [DescriptionAttribute("French text for the Prompt Section"),
             CategoryAttribute("5. Activity Wizard Info Text")]
        public virtual string Prompt_Fre
        {
            get { return myACS.IsPromptFNull() ? "": myACS.PromptF; }
            set 
            {
                if (value == "")
                    myACS.SetPromptFNull();
                else
                    myACS.PromptF = value; 
            }
        }

        [DescriptionAttribute("English text for the first Related Information Section"),
          CategoryAttribute("5. Activity Wizard Info Text")]
        public virtual string Rel_Info_0_Eng
        {
            get { return myACS.IsRel0ENull() ? "": myACS.Rel0E; }
            set 
            {
                if (value == "")
                    myACS.SetRel0ENull();
                else
                    myACS.Rel0E = value; 
            }
        }

        [DescriptionAttribute("French text for the first Related Information Section"),
             CategoryAttribute("5. Activity Wizard Info Text")]
        public virtual string Rel_Info_0_Fre
        {
            get { return myACS.IsRel0FNull() ? "" : myACS.Rel0F; }
            set
            {
                if (value == "")
                    myACS.SetRel0FNull();
                else
                    myACS.Rel0F = value;
            }
        }

        [DescriptionAttribute("English text for the second Related Information Section"),
          CategoryAttribute("5. Activity Wizard Info Text")]
        public virtual string Rel_Info_1_Eng
        {
            get { return myACS.IsRel1ENull() ? "" : myACS.Rel1E; }
            set
            {
                if (value == "")
                    myACS.SetRel1ENull();
                else
                    myACS.Rel1E = value;
            }
        }

        [DescriptionAttribute("French text for the second Related Information Section"),
             CategoryAttribute("5. Activity Wizard Info Text")]
        public virtual string Rel_Info_1_Fre
        {
            get { return myACS.IsRel1FNull() ? "" : myACS.Rel1F; }
            set
            {
                if (value == "")
                    myACS.SetRel1FNull();
                else
                    myACS.Rel1F = value;
            }
        }

        [DescriptionAttribute("English text for the third Related Information Section"),
         CategoryAttribute("5. Activity Wizard Info Text")]
        public virtual string Rel_Info_2_Eng
        {
            get { return myACS.IsRel2ENull() ? "" : myACS.Rel2E; }
            set
            {
                if (value == "")
                    myACS.SetRel2ENull();
                else
                    myACS.Rel2E = value;
            }
        }

        [DescriptionAttribute("French text for the third Related Information Section"),
             CategoryAttribute("5. Activity Wizard Info Text")]
        public virtual string Rel_Info_2_Fre
        {
            get { return myACS.IsRel2FNull() ? "" : myACS.Rel2F; }
            set
            {
                if (value == "")
                    myACS.SetRel2FNull();
                else
                    myACS.Rel2F = value;
            }
        }
        [DescriptionAttribute("English text for the fourth Related Information Section"),
         CategoryAttribute("5. Activity Wizard Info Text")]
        public virtual string Rel_Info_3_Eng
        {
            get { return myACS.IsRel3ENull() ? "" : myACS.Rel3E; }
            set
            {
                if (value == "")
                    myACS.SetRel3ENull();
                else
                    myACS.Rel3E = value;
            }
        }

        [DescriptionAttribute("French text for the fourth Related Information Section"),
             CategoryAttribute("5. Activity Wizard Info Text")]
        public virtual string Rel_Info_3_Fre
        {
            get { return myACS.IsRel3FNull() ? "" : myACS.Rel3F; }
            set
            {
                if (value == "")
                    myACS.SetRel3FNull();
                else
                    myACS.Rel3F = value;
            }
        }
        [DescriptionAttribute("English text for the fifth Related Information Section"),
         CategoryAttribute("5. Activity Wizard Info Text")]
        public virtual string Rel_Info_4_Eng
        {
            get { return myACS.IsRel4ENull() ? "" : myACS.Rel4E; }
            set
            {
                if (value == "")
                    myACS.SetRel4ENull();
                else
                    myACS.Rel4E = value;
            }
        }

        [DescriptionAttribute("French text for the fifth Related Information Section"),
             CategoryAttribute("5. Activity Wizard Info Text")]
        public virtual string Rel_Info_4_Fre
        {
            get { return myACS.IsRel4FNull() ? "" : myACS.Rel4F; }
            set
            {
                if (value == "")
                    myACS.SetRel4FNull();
                else
                    myACS.Rel4F = value;
            }
        }



        [BrowsableAttribute(false)]
        public override Point Out
        {
            get { return new Point(myRectangle.Right, (myRectangle.Top + myRectangle.Bottom) / 2); }
        }

        [BrowsableAttribute(false)]
        public override Point In
        {
            get { return new Point(myRectangle.Left, (myRectangle.Top + myRectangle.Bottom) / 2); }
        }

        [BrowsableAttribute(false)]
        public override Point Top
        {
            get { return new Point((myRectangle.Left + myRectangle.Right) / 2, myRectangle.Top); }
        }

        [BrowsableAttribute(false)]
        public override Point Bottom
        {
            get { return new Point((myRectangle.Left + myRectangle.Right) / 2, myRectangle.Bottom); }
        }

        [BrowsableAttribute(false)]
        public override Point Left
        {
            get { return new Point(myRectangle.Left, (myRectangle.Top + myRectangle.Bottom) / 2); }
        }

        [BrowsableAttribute(false)]
        public override Point Right
        {
            get { return new Point(myRectangle.Right, (myRectangle.Top + myRectangle.Bottom) / 2); }
        }
    }

    public class RoleCodeConverter : StringConverter
    {
        public static Dictionary<string, string> roles = new Dictionary<string, string>();
        public static Dictionary<string, string> rolesV = new Dictionary<string, string>();

        public RoleCodeConverter()
        {
            System.Data.DataTable dt = UIHelper.AtMng.GetFile().Codes("vRoleuContactType");
            roles.Clear();
            rolesV.Clear();
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                roles.Add(dr[0].ToString(), dr[1].ToString());
                rolesV.Add(dr[1].ToString(), dr[0].ToString());
            }
        }
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(roles.Values);
        }

    }

    public class ActivityCodeConverter : StringConverter
    {
        public static Dictionary<int, string> ac = new Dictionary<int, string>();
        public static Dictionary<string, int> acV = new Dictionary<string, int>();

        public ActivityCodeConverter()
        {
            System.Data.DataView dvAC = new System.Data.DataView(UIHelper.AtMng.acMng.DB.ActivityCode, "ACSeriesid is null and Obsolete=false", "ActivityCode",System.Data.DataViewRowState.CurrentRows);
            ac.Clear();
            acV.Clear();
            foreach (System.Data.DataRowView dvr in dvAC)
            {
                lmDatasets.ActivityConfig.ActivityCodeRow acr = (lmDatasets.ActivityConfig.ActivityCodeRow)dvr.Row;
                ac.Add(acr.ActivityCodeID,acr.ActivityCode+" - "+acr.ActivityNameEng);
                acV.Add(acr.ActivityCode + " - " + acr.ActivityNameEng, acr.ActivityCodeID);
            }
        }
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(ac.Values);
        }
    }

    public class SeriesConverter : StringConverter
    {
        public static Dictionary<int, string> ac = new Dictionary<int, string>();
        public static Dictionary<string, int> acV = new Dictionary<string, int>();

        public SeriesConverter()
        {
            System.Data.DataView dvAC = new System.Data.DataView(UIHelper.AtMng.acMng.DB.Series, "Obsolete=false", "SeriesDescEng", System.Data.DataViewRowState.CurrentRows);
            ac.Clear();
            acV.Clear();
            foreach (System.Data.DataRowView dvr in dvAC)
            {
                lmDatasets.ActivityConfig.SeriesRow acr = (lmDatasets.ActivityConfig.SeriesRow)dvr.Row;
                ac.Add(acr.SeriesId, acr.SeriesDescEng);
                acV.Add(acr.SeriesDescEng, acr.SeriesId);
            }
        }
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(ac.Values);
        }
    }

}
