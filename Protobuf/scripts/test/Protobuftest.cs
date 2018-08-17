using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protobuftest : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

        string s = JsonUtility.ToJson(transform.position);//position

        Vector3 v1 = new Vector3(3, 2, 1);

        //byte[] tempbyte = ProtoBufHelp.serialization<Vector3Protobuf>(new Vector3Protobuf(new Vector3(3, 2, 4)));
        byte[] tempbyte1 = ProtoBufHelp.serialization<Vector3Protobuf>(new Vector3Protobuf(transform.position));
        v1 = ProtoBufHelp.deserialization<Vector3Protobuf>(tempbyte1).Getprimary();

        Quaternion q, q1;
        byte[] tempbyte2 = ProtoBufHelp.serialization<QuaternionProtobuf>(new QuaternionProtobuf(transform.rotation));
        q = ProtoBufHelp.deserialization<QuaternionProtobuf>(tempbyte2).Getprimary();
        v1 = q.eulerAngles;
        s = JsonUtility.ToJson(transform.rotation);//position
        char[] temb = s.ToCharArray();
        q1 = JsonUtility.FromJson<Quaternion>(s);
        Vector3 v = new Vector3(3, 2, 1);

    }

    // Update is called once per frame
    void Update()
    {

    }

}