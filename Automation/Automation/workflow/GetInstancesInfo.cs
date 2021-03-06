﻿using System;
using System.Activities;
using ActivityLib;
using ActivityLib.Activities;
using Common;

namespace Automation.workflow
{
    public class GetInstancesInfo : LeafAction
    {
        protected override void Execute(NativeActivityContext context)
        {
            try
            {
                string instancesInfo = InstanceManager.GetInstance().GetInstances();
                Result r = Common.Result.SuccessResult();
                r.attach(instancesInfo);
                SetReturnMessage(context, r);
            }
            catch (Exception ex)
            {
                SetReturnMessage(context, Common.Result.ErrorResult(ex));
            }
        }
    }
}