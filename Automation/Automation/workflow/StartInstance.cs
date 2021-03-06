﻿using System;
using System.Activities;
using ActivityLib;
using ActivityLib.Activities;
using Common;

namespace Automation.workflow
{
    public class StartInstance : LeafAction
    {
        protected override void Execute(NativeActivityContext context)
        {
            try
            {
                string id = GetContextValue(context, Const.AttributeId);
                InstanceManager.GetInstance().GetTestInstance(id).Start();
                SetReturnMessage(context, Common.Result.SuccessResult());
            }
            catch (Exception ex)
            {
                SetReturnMessage(context, Common.Result.ErrorResult(ex));
            }
        }
    }
}