using UnityEngine;
using System.Runtime.Serialization;

namespace Scripts.SaveToFile.Surrogates{
    public class QuaternionSerializationSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            var q = (Quaternion)obj;
            info.AddValue("x", q.x);
            info.AddValue("y", q.y);
            info.AddValue("z", q.z);
            info.AddValue("w", q.w);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var q = (Quaternion)obj;
            q.x = (float)info.GetValue("x", typeof(float));
            q.y = (float)info.GetValue("y", typeof(float));
            q.z = (float)info.GetValue("z", typeof(float));
            q.w = (float)info.GetValue("w", typeof(float));
            obj = q;
            return obj;
        }
    }
}
