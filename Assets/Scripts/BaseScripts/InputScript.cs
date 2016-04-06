using UnityEngine;
using UnityEngine.EventSystems;

public class InputScript : MonoBehaviour
{
    /// <summary>
    /// 入力されたか
    /// </summary>
    public bool isInputDownFlag
    {
        protected set;
        get;
    }
    /// <summary>
    /// 入力が解除されたか
    /// </summary>
    public bool isInputUpFlag
    {
        protected set;
        get;
    }
    /// <summary>
    /// 入力された位置
    /// </summary>
    protected Vector3 downPosition = Vector3.zero;
    /// <summary>
    /// 入力が解除された位置
    /// </summary>
    protected Vector3 upPosition = Vector3.zero;
    /// <summary>
    /// 入力があるかどうかを返します
    /// </summary>
    /// <returns>true＝あり　false=無し</returns>
    public virtual bool isInputDown()
    {
        return false;
    }
    /// <summary>
    /// 入力が解除されたかを返します
    /// </summary>
    /// <returns>true=解除 false=未解除</returns>
    public virtual bool isInputUp()
    {
        return false;
    }
    /// <summary>
    /// 入力された場所を取得します
    /// </summary>
    /// <returns>入力されたスクリーン座標を取得する</returns>
    public virtual Vector3 getDownPosition()
    {
        return Vector3.zero;
    }
    /// <summary>
    /// マウスポインタ、あるいはタッチされている場所を返します
    /// </summary>
    /// <returns>マウスポインタあるいはタッチされた座標</returns>
    public virtual Vector3 getPosition()
    {
        return Input.mousePosition;
    }
    /// <summary>
    /// 入力が解除されたスクリーン座標を取得する
    /// </summary>
    /// <returns></returns>
    public virtual Vector3 getUpPosition()
    {
        return Vector3.zero;
    }
    /// <summary>
    /// 初期状態に戻します。
    /// </summary>
    public virtual void init()
    {

    }
    /// <summary>
    /// 処理実行
    /// </summary>
    public virtual void process()
    {

    }
}
