using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using ProtoBuf;
#region protobufbase
public class protobufbase
{

}
#endregion
#region Vector3Protobuf
[ProtoContract]
public class Vector3Protobuf : protobufbase
{
    public Vector3Protobuf()
    {

    }
    public Vector3Protobuf(Vector3 v)
    {
        x = v.x;
        y = v.y;
        z = v.z;
    }
    public Vector3 Getprimary()
    {
        Vector3 v = new Vector3();
        v.x = x;
        v.y = y;
        v.z = z;
        return v;
    }
    [ProtoMember(1)]
    public float x { get; set; }
    [ProtoMember(2)]
    public float y { get; set; }
    [ProtoMember(3)]
    public float z { get; set; }
}
#endregion
#region QuaternionProtobuf
[ProtoContract]
public class QuaternionProtobuf : protobufbase
{
    public QuaternionProtobuf()
    {

    }
    public QuaternionProtobuf(Quaternion v)
    {
        x = v.x;
        y = v.y;
        z = v.z;
        w = v.w;

    }
    public Quaternion Getprimary()
    {
        Quaternion v = new Quaternion();
        v.x = x;
        v.y = y;
        v.z = z;
        v.w = w;
        return v;
    }
    [ProtoMember(1)]
    public float x { get; set; }
    [ProtoMember(2)]
    public float y { get; set; }
    [ProtoMember(3)]
    public float z { get; set; }
    [ProtoMember(4)]
    public float w { get; set; }
}
#endregion
#region ProtoBufHelp 
public static class ProtoBufHelp
{
    public static byte[] serialization<T>(T obj) where T : protobufbase, new()
    {
        if (obj == null) return null;
        try
        {
            using (MemoryStream stream = new MemoryStream())
            {
                Serializer.Serialize(stream, obj);
                return stream.ToArray();
            }
        }
        catch
        {
            throw;
        }
    }

    public static T deserialization<T>(byte[] data) where T : protobufbase, new()
    {
        if (data == null) return default(T);
        try
        {
            using (MemoryStream stream = new MemoryStream(data))
            {
                return Serializer.Deserialize<T>(stream);
            }
        }
        catch
        {
            throw;
        }
    }

}
#endregion