﻿//
// ColorizationTests.cs
//
// Author:
//       Mike Krüger <mkrueger@xamarin.com>
//
// Copyright (c) 2015 Xamarin Inc. (http://xamarin.com)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using NUnit.Framework;

namespace MonoDevelop.Ide.FindInFiles
{
	[TestFixture]
	public class ColorizationTests
	{
		[Test]
		public void TestSimple ()
		{
			var result = PangoHelper.ColorMarkupBackground (
				"simple",
				1,
				5,
				new Mono.TextEditor.HslColor (1d, 1d, 1d)
			);
			Assert.AreEqual ("s<span background=\"#FFFFFF\">impl</span>e", result);
		}

		/// <summary>
		/// Bug 25110 - Weird search result colours
		/// </summary>
		[Test]
		public void TestBug25110 ()
		{
			var result = PangoHelper.ColorMarkupBackground (
				"<span foreground=\"#000000\">Console.WriteLine (</span><span foreground=\"#3364A4\">base</span><span foreground=\"#000000\">.ToString());</span>",
				19,
				24,
				new Mono.TextEditor.HslColor (1d, 1d, 1d)
			);
			Assert.AreEqual ("<span foreground=\"#000000\">Console.WriteLine (</span><span foreground=\"#3364A4\"><span background=\"#FFFFFF\">base</span><span foreground=\"#000000\"><span background=\"#FFFFFF\">.</span>ToString());</span>", result);
		}


		/// <summary>
		/// Bug 25836 - Search Results widget displaying wrong highlight
		/// </summary>
		[Test]
		public void TestBug25836 ()
		{
			var result = PangoHelper.ColorMarkupBackground (
				"<span foreground=\"#000000\">List&lt;RevisionPath&gt; foo;</span>",
				5,
				17,
				new Mono.TextEditor.HslColor (1d, 1d, 1d)
			);
			Assert.AreEqual ("<span foreground=\"#000000\">List&lt;<span background=\"#FFFFFF\">RevisionPath</span>&gt; foo;</span>", result);
		}
	}
}

