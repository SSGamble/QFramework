/****************************************************************************
 * Copyright (c) 2017 liangxie
 * 
 * http://qframework.io
 * https://github.com/liangxiegame/QFramework
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 ****************************************************************************/

using QF.Action;
using QF.Extensions;

namespace QF.Res
{
	using System;
	
	public class AudioSoundNode : NodeAction
	{
		public string SoundName;

		public System.Action OnSoundBeganCallback
		{
			get { return OnBeganCallback; }
			set { OnBeganCallback = value; }
		}

		public System.Action OnSoundEndedCallback
		{
			get { return OnEndedCallback; }
			set { OnEndedCallback = value; }
		}

		public AudioSoundNode(string soundName)
		{
			SoundName = soundName;
		}

		protected override void OnBegin()
		{
			base.OnBegin();
			AudioManager.Instance.SendMsg(new AudioSoundMsg(SoundName, OnSoundBeganCallback, delegate
			{
				Finished = true;
			}));
		}

		protected override void OnExecute(float dt)
		{
			
		}

		protected override void OnEnd()
		{
			OnSoundEndedCallback.InvokeGracefully();
		}

		protected override void OnDispose()
		{
			SoundName = null;
		}
	}
}