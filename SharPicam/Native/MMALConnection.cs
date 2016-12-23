﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SharPicam.Native
{
    public static class MMALConnection
    {
        public const uint MMAL_CONNECTION_FLAG_TUNNELLING = 0x1u;
        public const uint MMAL_CONNECTION_FLAG_ALLOCATION_ON_INPUT = 0x2u;
        public const uint MMAL_CONNECTION_FLAG_ALLOCATION_ON_OUTPUT = 0x4u;
        public const uint MMAL_CONNECTION_FLAG_KEEP_BUFFER_REQUIREMENTS = 0x8u;
        public const uint MMAL_CONNECTION_FLAG_DIRECT = 0x10u;

        //typedef - Pointer to MMAL_CONNECTION_T -> Returns MMAL_BOOL_T
        public unsafe delegate int MMAL_CONNECTION_CALLBACK_T(MMAL_CONNECTION_T* conn);

        [DllImport("libmmal.so", EntryPoint = "mmal_connection_create", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern MMALUtil.MMAL_STATUS_T mmal_connection_create(MMAL_CONNECTION_T** connection, MMAL_PORT_T* output, MMAL_PORT_T* input, uint flags);

        [DllImport("libmmal.so", EntryPoint = "mmal_connection_acquire", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern void mmal_connection_acquire(MMAL_CONNECTION_T* connection);

        [DllImport("libmmal.so", EntryPoint = "mmal_connection_release", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern MMALUtil.MMAL_STATUS_T mmal_connection_release(MMAL_CONNECTION_T* connection);

        [DllImport("libmmal.so", EntryPoint = "mmal_connection_destroy", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern MMALUtil.MMAL_STATUS_T mmal_connection_destroy(MMAL_CONNECTION_T* connection);

        [DllImport("libmmal.so", EntryPoint = "mmal_connection_enable", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern MMALUtil.MMAL_STATUS_T mmal_connection_enable(MMAL_CONNECTION_T* connection);

        [DllImport("libmmal.so", EntryPoint = "mmal_connection_disable", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern MMALUtil.MMAL_STATUS_T mmal_connection_disable(MMAL_CONNECTION_T* connection);

        [DllImport("libmmal.so", EntryPoint = "mmal_connection_event_format_changed", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern MMALUtil.MMAL_STATUS_T mmal_connection_event_format_changed(MMAL_CONNECTION_T* connection, MMAL_BUFFER_HEADER_T* buffer);

    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct MMAL_CONNECTION_T
    {
        public IntPtr userData, callback;
        public uint isEnabled, flags;
        public MMAL_PORT_T* input, output;
        public MMAL_POOL_T* pool;
        public MMAL_QUEUE_T* queue;
        public char* name;
        public long timeSetup, timeEnable, timeDisable;

        public MMAL_CONNECTION_T(IntPtr userData, IntPtr callback, uint isEnabled, uint flags, MMAL_PORT_T* input, MMAL_PORT_T* output,
                                 MMAL_POOL_T* pool, MMAL_QUEUE_T* queue, char* name, long timeSetup, long timeEnable, long timeDisable)
        {
            this.userData = userData;
            this.callback = callback;
            this.isEnabled = isEnabled;
            this.flags = flags;
            this.input = input;
            this.output = output;
            this.pool = pool;
            this.queue = queue;
            this.name = name;
            this.timeSetup = timeSetup;
            this.timeEnable = timeEnable;
            this.timeDisable = timeDisable;
        }
    }

}