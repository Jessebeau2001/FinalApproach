using System;
using GXPEngine;

public struct Vec2
{
	public float x;
	public float y;

	public Vec2(float x = 0, float y = 0)
	{
		this.x = x;
		this.y = y;
	}

	public static Vec2 operator+ (Vec2 left, Vec2 right)
	{
		return new Vec2(left.x + right.x, left.y + right.y);
	}

	public override string ToString()
	{
		return String.Format("({0},{1}", x, y);
	}

	public static Vec2 operator- (Vec2 left, Vec2 right)
	{
		return new Vec2(left.x - right.x, left.y - right.y);
	}

	public static Vec2 operator* (Vec2 left, float multiplier)
	{
		return new Vec2(left.x * multiplier, left.y * multiplier);
	}

	public static Vec2 operator* (float multiplier, Vec2 right)
	{
		return new Vec2(right.x * multiplier, right.y * multiplier);
	}

	public float Length()
	{
		return Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
	}

	public void Normalize()
	{
		float length = Length();
		if (length == 0) return;
		x /= length;
		y /= length;
	}

	public Vec2 Normalized()
	{
		Vec2 v = this;
		v.Normalize();
		return v;
	}

	public void SetXY(float x, float y)
	{
		this.x = x;
		this.y = y;
	}

	public static void UnitTest()
	{

	}
}