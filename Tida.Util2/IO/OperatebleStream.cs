using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tida.IO {
    /// <summary>
    /// 当位置发生变化时可通知位置的Stream;
    /// 以应对不能使用异步方法的类在进行耗时操作时不能取消,通知的缺点;
    /// </summary>
    public class OperatebleStream : Stream {
        public OperatebleStream(Stream oriStream) {
            OriStream = oriStream ?? throw new ArgumentNullException(nameof(oriStream));
        }

        /// <summary>
        /// 是否被中止;
        /// </summary>
        public bool Broken { get; private set; }
        public void Break() {
            Broken = true;
        }

        /// <summary>
        /// 原始流;
        /// </summary>
        public Stream OriStream { get; }

        public override bool CanRead => !Broken && OriStream.CanRead;

        public override bool CanSeek => !Broken && OriStream.CanSeek;

        public override bool CanWrite => !Broken && OriStream.CanWrite;

        public override long Length => OriStream.Length;

        public override long Position { get => OriStream.Position; set => OriStream.Position = value; }

        public override void Flush() => OriStream.Flush();

        public event EventHandler<long> PositionChanged;
        public override int Read(byte[] buffer, int offset, int count) {
            if (!Broken) {
                var read = OriStream.Read(buffer, offset, count);
                PositionChanged?.Invoke(this, OriStream.Position);
                return read;
            }
            return 0;
        }

        public override long Seek(long offset, SeekOrigin origin) => OriStream.Seek(offset, origin);

        public override void SetLength(long value) => OriStream.SetLength(value);

        public override void Write(byte[] buffer, int offset, int count) {
            if (!Broken) {
                OriStream.Write(buffer, offset, count);
                PositionChanged?.Invoke(this, OriStream.Position);
            }
            return;
        }
    }
}
