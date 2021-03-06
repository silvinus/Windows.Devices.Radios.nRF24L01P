﻿using System.Collections.Generic;
using Windows.Devices.Radios.nRF24L01P.Network.Enums;

namespace Windows.Devices.Radios.nRF24L01P.Network.Interfaces
{
    public interface INetwork
    {
        INetworkAddressing NetworkAddressing { get; set; }
        bool MultiCaseRelay { get; set; }
        uint TransmitTimeout { get; set; }
        uint RouteTimeout { get; set; }
        byte[] FrameBuffer { get; set; }
        Queue<INetworkFrame> ExternalQueue { get; set; }
        bool ReturnSysMessages { get; set; }
        NetworkFlags NetworkFlags { get; set; }
        void Begin(ushort nodeAddress);
        void Begin(byte channel, ushort nodeAddress);
        byte Update();
        bool Available();
        ushort Peek(INetworkHeader networkHeader);
        ushort Read(INetworkHeader networkHeader, byte message, ushort maxLength);
        bool Write(INetworkHeader networkHeader, byte[] message, ushort length);
        bool Write(INetworkHeader networkHeader, byte[] message, ushort length, ushort writeDirect);
        bool MultiCast(INetworkHeader networkHeader, byte[] message, ushort length, byte level);
        void MultiCastLevel(byte level);
        void Falures(ref uint fails, ref uint ok);
    }
}
