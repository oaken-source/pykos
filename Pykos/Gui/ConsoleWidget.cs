
/******************************************************************************
 *                    pykos - bringing python to KSP                          *
 *                                                                            *
 *    Copyright (C) 2015  Andreas Grapentin                                   *
 *                                                                            *
 *    This program is free software: you can redistribute it and/or modify    *
 *    it under the terms of the GNU General Public License as published by    *
 *    the Free Software Foundation, either version 3 of the License, or       *
 *    (at your option) any later version.                                     *
 *                                                                            *
 *    This program is distributed in the hope that it will be useful,         *
 *    but WITHOUT ANY WARRANTY; without even the implied warranty of          *
 *    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the           *
 *    GNU General Public License for more details.                            *
 *                                                                            *
 *    You should have received a copy of the GNU General Public License       *
 *    along with this program.  If not, see <http://www.gnu.org/licenses/>.   *
 ******************************************************************************/

using PyKOS.Util;
using PyKOS.Python;

using System;
using UnityEngine;

namespace PyKOS.Gui
{

public class ConsoleWidget : Widget
{

  private Rect dimensions;
  private string input = "";
  private Vector2 scroll = new Vector2(0, Mathf.Infinity);

  private const float inputEditHeight = 20;

  public ConsoleWidget (MonoBehaviour _parent, float left, float top, float width, float height) : base(_parent)
    {
      dimensions = new Rect(left, top, width, height);
    }

  override public void redraw ()
    {
      if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Return)
        {
          Interpreter.execute(input);
          input = "";
          scroll = new Vector2(0, Mathf.Infinity);
          Event.current.Use();
        }

      GUILayout.BeginArea(dimensions);
      GUILayout.BeginVertical();
      scroll = GUILayout.BeginScrollView(scroll, GUILayout.ExpandHeight(true));
      GUILayout.TextArea(Interpreter.output, GUILayout.ExpandHeight(true));
      GUILayout.EndScrollView();

      GUILayout.BeginHorizontal();
      GUILayout.Label(">>>", GUILayout.ExpandWidth(false));
      input = GUILayout.TextArea(input, GUILayout.ExpandWidth(true));
      GUILayout.EndHorizontal();
      GUILayout.EndVertical();
      GUILayout.EndArea();
    }

}

}

