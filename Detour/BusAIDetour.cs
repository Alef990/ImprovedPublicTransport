﻿// Decompiled with JetBrains decompiler
// Type: ImprovedPublicTransport.BusAIMod
// Assembly: ImprovedPublicTransport, Version=1.0.6177.17409, Culture=neutral, PublicKeyToken=null
// MVID: 76F370C5-F40B-41AE-AA9D-1E3F87E934D3
// Assembly location: C:\Games\Steam\steamapps\workshop\content\255710\424106600\ImprovedPublicTransport.dll

using System;
using ColossalFramework;
using ImprovedPublicTransport2.RedirectionFramework;
using ImprovedPublicTransport2.RedirectionFramework.Attributes;
using UnityEngine;

namespace ImprovedPublicTransport2.Detour
{
    [TargetType(typeof(BusAI))]
    public class BusAIDetour : CarAI
    {
        [RedirectMethod]
        public override bool CanLeave(ushort vehicleID, ref Vehicle vehicleData)
        {
            if ((int)vehicleData.m_leadingVehicle == 0 && (int)vehicleData.m_waitCounter < 12 ||
                !base.CanLeave(vehicleID, ref vehicleData))
            {
                //begin mod(+): track if unbunching happens
                VehicleManagerMod.m_cachedVehicleData[(int)vehicleID].IsUnbunchingInProgress = false;
                //end mod
                return false;
            }
            //begin mod(+): no unbunching for evac buses or if only 1 bus on line!
            if (vehicleData.Info?.m_class?.m_service == ItemClass.Service.Disaster || (vehicleData.m_nextLineVehicle == 0 && Singleton<TransportManager>.instance.m_lines
                                                                                           .m_buffer[(int)vehicleData.m_transportLine].m_vehicles == vehicleID))
            {
                VehicleManagerMod.m_cachedVehicleData[vehicleID].IsUnbunchingInProgress = false;
                return true;
            }
            //end mod

            if ((int)vehicleData.m_leadingVehicle == 0 && (int)vehicleData.m_transportLine != 0)
            {
                //begin mod(+): Check if unbunching enabled for this line & stop. track if unbunching happens. Don't divide m_waitCounter by 2^4
                ushort currentStop = VehicleManagerMod.m_cachedVehicleData[vehicleID].CurrentStop;
                if (currentStop != 0 && NetManagerMod.m_cachedNodeData[currentStop].Unbunching &&
                                         TransportLineMod.GetUnbunchingState(vehicleData.m_transportLine))
                {
                    var canLeaveStop = Singleton<TransportManager>.instance.m_lines
                        .m_buffer[(int)vehicleData.m_transportLine]
                        .CanLeaveStop(vehicleData.m_targetBuilding, (int)vehicleData.m_waitCounter);
                    VehicleManagerMod.m_cachedVehicleData[vehicleID].IsUnbunchingInProgress = !canLeaveStop;
                    return canLeaveStop;
                }
                //end mod
            }
            //begin mod(+): track if unbunching happens
            VehicleManagerMod.m_cachedVehicleData[vehicleID].IsUnbunchingInProgress = false;
            //end mod
            return true;
        }

        [RedirectMethod]
        private bool ArriveAtTarget(ushort vehicleID, ref Vehicle data)
        {
            if ((int)data.m_targetBuilding == 0)
            {
                Singleton<VehicleManager>.instance.ReleaseVehicle(vehicleID);
                return true;
            }
            ushort nextStop = 0;
            if ((int)data.m_transportLine != 0)
                nextStop = TransportLine.GetNextStop(data.m_targetBuilding);
            ushort targetBuilding = data.m_targetBuilding;
            //begin mod(+): remember transfer size
            ushort transferSize1 = data.m_transferSize;
            //end mod
            this.UnloadPassengers(vehicleID, ref data, targetBuilding, nextStop);
            //begin mod(+): track various parameters
            ushort num1 = (ushort)((uint)transferSize1 - (uint)data.m_transferSize);
            VehicleManagerMod.m_cachedVehicleData[(int)vehicleID].LastStopGonePassengers = (int)num1;
            VehicleManagerMod.m_cachedVehicleData[(int)vehicleID].CurrentStop = targetBuilding;
            NetManagerMod.m_cachedNodeData[(int)targetBuilding].PassengersOut += (int)num1;
            //end mod
            if ((int)nextStop == 0)
            {
                data.m_flags |= Vehicle.Flags.GoingBack;
                if (!this.StartPathFind(vehicleID, ref data))
                    return true;
                data.m_flags &= Vehicle.Flags.Created | Vehicle.Flags.Deleted | Vehicle.Flags.Spawned | Vehicle.Flags.Inverted | Vehicle.Flags.TransferToTarget | Vehicle.Flags.TransferToSource | Vehicle.Flags.Emergency1 | Vehicle.Flags.Emergency2 | Vehicle.Flags.WaitingPath | Vehicle.Flags.Stopped | Vehicle.Flags.Leaving | Vehicle.Flags.Reversed | Vehicle.Flags.TakingOff | Vehicle.Flags.Flying | Vehicle.Flags.Landing | Vehicle.Flags.WaitingSpace | Vehicle.Flags.WaitingCargo | Vehicle.Flags.GoingBack | Vehicle.Flags.WaitingTarget | Vehicle.Flags.Importing | Vehicle.Flags.Exporting | Vehicle.Flags.Parking | Vehicle.Flags.CustomName | Vehicle.Flags.OnGravel | Vehicle.Flags.WaitingLoading | Vehicle.Flags.Congestion | Vehicle.Flags.DummyTraffic | Vehicle.Flags.Underground | Vehicle.Flags.Transition | Vehicle.Flags.InsideBuilding | Vehicle.Flags.LeftHandDrive;
                data.m_flags |= Vehicle.Flags.Stopped;
                data.m_waitCounter = (byte)0;
            }
            else
            {
                data.m_targetBuilding = nextStop;
                if (!this.StartPathFind(vehicleID, ref data))
                    return true;
                //begin mod(+): remember transfer size
                ushort transferSize2 = data.m_transferSize;
                //end mod
                this.LoadPassengers(vehicleID, ref data, targetBuilding, nextStop);
                //begin mod(+): track various parameters
                ushort num2 = (ushort)((uint)data.m_transferSize - (uint)transferSize2);
                int ticketPrice = data.Info.m_vehicleAI.GetTicketPrice(vehicleID, ref data);
                VehicleManagerMod.m_cachedVehicleData[(int)vehicleID].Add((int)num2, ticketPrice);
                NetManagerMod.m_cachedNodeData[(int)targetBuilding].PassengersIn += (int)num2;
                //end mod
                data.m_flags &= Vehicle.Flags.Created | Vehicle.Flags.Deleted | Vehicle.Flags.Spawned | Vehicle.Flags.Inverted | Vehicle.Flags.TransferToTarget | Vehicle.Flags.TransferToSource | Vehicle.Flags.Emergency1 | Vehicle.Flags.Emergency2 | Vehicle.Flags.WaitingPath | Vehicle.Flags.Stopped | Vehicle.Flags.Leaving | Vehicle.Flags.Reversed | Vehicle.Flags.TakingOff | Vehicle.Flags.Flying | Vehicle.Flags.Landing | Vehicle.Flags.WaitingSpace | Vehicle.Flags.WaitingCargo | Vehicle.Flags.GoingBack | Vehicle.Flags.WaitingTarget | Vehicle.Flags.Importing | Vehicle.Flags.Exporting | Vehicle.Flags.Parking | Vehicle.Flags.CustomName | Vehicle.Flags.OnGravel | Vehicle.Flags.WaitingLoading | Vehicle.Flags.Congestion | Vehicle.Flags.DummyTraffic | Vehicle.Flags.Underground | Vehicle.Flags.Transition | Vehicle.Flags.InsideBuilding | Vehicle.Flags.LeftHandDrive;
                data.m_flags |= Vehicle.Flags.Stopped;
                data.m_waitCounter = (byte)0;
            }
            return false;
        }

        [RedirectReverse]
        private void LoadPassengers(ushort vehicleID, ref Vehicle data, ushort currentStop,
            ushort nextStop)
        {
            UnityEngine.Debug.Log("LoadPassengers");
        }

        [RedirectReverse]
        private void UnloadPassengers(ushort vehicleID, ref Vehicle data, ushort currentStop,
            ushort nextStop)
        {
            UnityEngine.Debug.Log("UnloadPassengers");
        }
    }
}