// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protocol.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Google.Protobuf.Protocol {

  /// <summary>Holder for reflection information generated from Protocol.proto</summary>
  public static partial class ProtocolReflection {

    #region Descriptor
    /// <summary>File descriptor for Protocol.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ProtocolReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cg5Qcm90b2NvbC5wcm90bxIIUHJvdG9jb2waH2dvb2dsZS9wcm90b2J1Zi90",
            "aW1lc3RhbXAucHJvdG8iKgoHVmVjdG9yMxIJCgF4GAEgASgCEgkKAXkYAiAB",
            "KAISCQoBehgDIAEoAiKhAQoNVHJhbnNmb3JtSW5mbxIkCgVzdGF0ZRgBIAEo",
            "DjIVLlByb3RvY29sLkVudGl0eVN0YXRlEiMKCHBvc2l0aW9uGAIgASgLMhEu",
            "UHJvdG9jb2wuVmVjdG9yMxIjCghyb3RhdGlvbhgDIAEoCzIRLlByb3RvY29s",
            "LlZlY3RvcjMSIAoFc2NhbGUYBCABKAsyES5Qcm90b2NvbC5WZWN0b3IzImcK",
            "CFN0YXRJbmZvEg0KBWxldmVsGAEgASgFEgoKAmhwGAIgASgFEg0KBW1heEhw",
            "GAMgASgFEhAKCGF0a1Bvd2VyGAQgASgFEg0KBXNwZWVkGAUgASgCEhAKCHRv",
            "dGFsRXhwGAYgASgFIpgBCgpFbnRpdHlJbmZvEgoKAmlkGAEgASgFEgwKBG5h",
            "bWUYAiABKAkSIgoEdHlwZRgDIAEoDjIULlByb3RvY29sLkVudGl0eVR5cGUS",
            "KgoJdHJhbnNmb3JtGAQgASgLMhcuUHJvdG9jb2wuVHJhbnNmb3JtSW5mbxIg",
            "CgRzdGF0GAUgASgLMhIuUHJvdG9jb2wuU3RhdEluZm8iFQoTU19Db25uZWN0",
            "ZWRUb1NlcnZlciovCgpFbnRpdHlUeXBlEggKBE5PTkUQABIKCgZQTEFZRVIQ",
            "ARILCgdNT05TVEVSEAIqNgoLRW50aXR5U3RhdGUSCAoESURMRRAAEggKBE1P",
            "VkUQARIJCgVTS0lMTBACEggKBERFQUQQAyo3CglTa2lsbFR5cGUSEwoPU0tJ",
            "TExfVFlQRV9OT05FEAASFQoRU0tJTExfVFlQRV9NQU5VQUwQASpnCghJdGVt",
            "VHlwZRISCg5JVEVNX1RZUEVfTk9ORRAAEhQKEElURU1fVFlQRV9XRUFQT04Q",
            "ARIYChRJVEVNX1RZUEVfQ09OU1VNQUJMRRACEhcKE0lURU1fVFlQRV9BQ0NF",
            "U1NPUlkQAypPCgpXZWFwb25UeXBlEhQKEFdFQVBPTl9UWVBFX05PTkUQABIV",
            "ChFXRUFQT05fVFlQRV9TV09SRBABEhQKEFdFQVBPTl9UWVBFX1dBTkQQAipG",
            "Cg5Db25zdW1hYmxlVHlwZRIYChRDT05TVU1BQkxFX1RZUEVfTk9ORRAAEhoK",
            "FkNPTlNVTUFCTEVfVFlQRV9QT1RJT04QASoiCgVNc2dJZBIZChVTX0NPTk5F",
            "Q1RFRF9UT19TRVJWRVIQAEIbqgIYR29vZ2xlLlByb3RvYnVmLlByb3RvY29s",
            "YgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.TimestampReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::Google.Protobuf.Protocol.EntityType), typeof(global::Google.Protobuf.Protocol.EntityState), typeof(global::Google.Protobuf.Protocol.SkillType), typeof(global::Google.Protobuf.Protocol.ItemType), typeof(global::Google.Protobuf.Protocol.WeaponType), typeof(global::Google.Protobuf.Protocol.ConsumableType), typeof(global::Google.Protobuf.Protocol.MsgId), }, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Protobuf.Protocol.Vector3), global::Google.Protobuf.Protocol.Vector3.Parser, new[]{ "X", "Y", "Z" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Protobuf.Protocol.TransformInfo), global::Google.Protobuf.Protocol.TransformInfo.Parser, new[]{ "State", "Position", "Rotation", "Scale" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Protobuf.Protocol.StatInfo), global::Google.Protobuf.Protocol.StatInfo.Parser, new[]{ "Level", "Hp", "MaxHp", "AtkPower", "Speed", "TotalExp" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Protobuf.Protocol.EntityInfo), global::Google.Protobuf.Protocol.EntityInfo.Parser, new[]{ "Id", "Name", "Type", "Transform", "Stat" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Protobuf.Protocol.S_ConnectedToServer), global::Google.Protobuf.Protocol.S_ConnectedToServer.Parser, null, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  public enum EntityType {
    [pbr::OriginalName("NONE")] None = 0,
    [pbr::OriginalName("PLAYER")] Player = 1,
    [pbr::OriginalName("MONSTER")] Monster = 2,
  }

  public enum EntityState {
    [pbr::OriginalName("IDLE")] Idle = 0,
    [pbr::OriginalName("MOVE")] Move = 1,
    [pbr::OriginalName("SKILL")] Skill = 2,
    [pbr::OriginalName("DEAD")] Dead = 3,
  }

  public enum SkillType {
    [pbr::OriginalName("SKILL_TYPE_NONE")] None = 0,
    [pbr::OriginalName("SKILL_TYPE_MANUAL")] Manual = 1,
  }

  public enum ItemType {
    [pbr::OriginalName("ITEM_TYPE_NONE")] None = 0,
    [pbr::OriginalName("ITEM_TYPE_WEAPON")] Weapon = 1,
    [pbr::OriginalName("ITEM_TYPE_CONSUMABLE")] Consumable = 2,
    [pbr::OriginalName("ITEM_TYPE_ACCESSORY")] Accessory = 3,
  }

  public enum WeaponType {
    [pbr::OriginalName("WEAPON_TYPE_NONE")] None = 0,
    [pbr::OriginalName("WEAPON_TYPE_SWORD")] Sword = 1,
    [pbr::OriginalName("WEAPON_TYPE_WAND")] Wand = 2,
  }

  public enum ConsumableType {
    [pbr::OriginalName("CONSUMABLE_TYPE_NONE")] None = 0,
    [pbr::OriginalName("CONSUMABLE_TYPE_POTION")] Potion = 1,
  }

  public enum MsgId {
    [pbr::OriginalName("S_CONNECTED_TO_SERVER")] SConnectedToServer = 0,
  }

  #endregion

  #region Messages
  public sealed partial class Vector3 : pb::IMessage<Vector3> {
    private static readonly pb::MessageParser<Vector3> _parser = new pb::MessageParser<Vector3>(() => new Vector3());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Vector3> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Protobuf.Protocol.ProtocolReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Vector3() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Vector3(Vector3 other) : this() {
      x_ = other.x_;
      y_ = other.y_;
      z_ = other.z_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Vector3 Clone() {
      return new Vector3(this);
    }

    /// <summary>Field number for the "x" field.</summary>
    public const int XFieldNumber = 1;
    private float x_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float X {
      get { return x_; }
      set {
        x_ = value;
      }
    }

    /// <summary>Field number for the "y" field.</summary>
    public const int YFieldNumber = 2;
    private float y_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float Y {
      get { return y_; }
      set {
        y_ = value;
      }
    }

    /// <summary>Field number for the "z" field.</summary>
    public const int ZFieldNumber = 3;
    private float z_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float Z {
      get { return z_; }
      set {
        z_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Vector3);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Vector3 other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(X, other.X)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Y, other.Y)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Z, other.Z)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (X != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(X);
      if (Y != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Y);
      if (Z != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Z);
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (X != 0F) {
        output.WriteRawTag(13);
        output.WriteFloat(X);
      }
      if (Y != 0F) {
        output.WriteRawTag(21);
        output.WriteFloat(Y);
      }
      if (Z != 0F) {
        output.WriteRawTag(29);
        output.WriteFloat(Z);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (X != 0F) {
        size += 1 + 4;
      }
      if (Y != 0F) {
        size += 1 + 4;
      }
      if (Z != 0F) {
        size += 1 + 4;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Vector3 other) {
      if (other == null) {
        return;
      }
      if (other.X != 0F) {
        X = other.X;
      }
      if (other.Y != 0F) {
        Y = other.Y;
      }
      if (other.Z != 0F) {
        Z = other.Z;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 13: {
            X = input.ReadFloat();
            break;
          }
          case 21: {
            Y = input.ReadFloat();
            break;
          }
          case 29: {
            Z = input.ReadFloat();
            break;
          }
        }
      }
    }

  }

  public sealed partial class TransformInfo : pb::IMessage<TransformInfo> {
    private static readonly pb::MessageParser<TransformInfo> _parser = new pb::MessageParser<TransformInfo>(() => new TransformInfo());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<TransformInfo> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Protobuf.Protocol.ProtocolReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TransformInfo() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TransformInfo(TransformInfo other) : this() {
      state_ = other.state_;
      position_ = other.position_ != null ? other.position_.Clone() : null;
      rotation_ = other.rotation_ != null ? other.rotation_.Clone() : null;
      scale_ = other.scale_ != null ? other.scale_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TransformInfo Clone() {
      return new TransformInfo(this);
    }

    /// <summary>Field number for the "state" field.</summary>
    public const int StateFieldNumber = 1;
    private global::Google.Protobuf.Protocol.EntityState state_ = global::Google.Protobuf.Protocol.EntityState.Idle;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.Protocol.EntityState State {
      get { return state_; }
      set {
        state_ = value;
      }
    }

    /// <summary>Field number for the "position" field.</summary>
    public const int PositionFieldNumber = 2;
    private global::Google.Protobuf.Protocol.Vector3 position_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.Protocol.Vector3 Position {
      get { return position_; }
      set {
        position_ = value;
      }
    }

    /// <summary>Field number for the "rotation" field.</summary>
    public const int RotationFieldNumber = 3;
    private global::Google.Protobuf.Protocol.Vector3 rotation_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.Protocol.Vector3 Rotation {
      get { return rotation_; }
      set {
        rotation_ = value;
      }
    }

    /// <summary>Field number for the "scale" field.</summary>
    public const int ScaleFieldNumber = 4;
    private global::Google.Protobuf.Protocol.Vector3 scale_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.Protocol.Vector3 Scale {
      get { return scale_; }
      set {
        scale_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as TransformInfo);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(TransformInfo other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (State != other.State) return false;
      if (!object.Equals(Position, other.Position)) return false;
      if (!object.Equals(Rotation, other.Rotation)) return false;
      if (!object.Equals(Scale, other.Scale)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (State != global::Google.Protobuf.Protocol.EntityState.Idle) hash ^= State.GetHashCode();
      if (position_ != null) hash ^= Position.GetHashCode();
      if (rotation_ != null) hash ^= Rotation.GetHashCode();
      if (scale_ != null) hash ^= Scale.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (State != global::Google.Protobuf.Protocol.EntityState.Idle) {
        output.WriteRawTag(8);
        output.WriteEnum((int) State);
      }
      if (position_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(Position);
      }
      if (rotation_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(Rotation);
      }
      if (scale_ != null) {
        output.WriteRawTag(34);
        output.WriteMessage(Scale);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (State != global::Google.Protobuf.Protocol.EntityState.Idle) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) State);
      }
      if (position_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Position);
      }
      if (rotation_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Rotation);
      }
      if (scale_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Scale);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(TransformInfo other) {
      if (other == null) {
        return;
      }
      if (other.State != global::Google.Protobuf.Protocol.EntityState.Idle) {
        State = other.State;
      }
      if (other.position_ != null) {
        if (position_ == null) {
          Position = new global::Google.Protobuf.Protocol.Vector3();
        }
        Position.MergeFrom(other.Position);
      }
      if (other.rotation_ != null) {
        if (rotation_ == null) {
          Rotation = new global::Google.Protobuf.Protocol.Vector3();
        }
        Rotation.MergeFrom(other.Rotation);
      }
      if (other.scale_ != null) {
        if (scale_ == null) {
          Scale = new global::Google.Protobuf.Protocol.Vector3();
        }
        Scale.MergeFrom(other.Scale);
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            State = (global::Google.Protobuf.Protocol.EntityState) input.ReadEnum();
            break;
          }
          case 18: {
            if (position_ == null) {
              Position = new global::Google.Protobuf.Protocol.Vector3();
            }
            input.ReadMessage(Position);
            break;
          }
          case 26: {
            if (rotation_ == null) {
              Rotation = new global::Google.Protobuf.Protocol.Vector3();
            }
            input.ReadMessage(Rotation);
            break;
          }
          case 34: {
            if (scale_ == null) {
              Scale = new global::Google.Protobuf.Protocol.Vector3();
            }
            input.ReadMessage(Scale);
            break;
          }
        }
      }
    }

  }

  public sealed partial class StatInfo : pb::IMessage<StatInfo> {
    private static readonly pb::MessageParser<StatInfo> _parser = new pb::MessageParser<StatInfo>(() => new StatInfo());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<StatInfo> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Protobuf.Protocol.ProtocolReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public StatInfo() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public StatInfo(StatInfo other) : this() {
      level_ = other.level_;
      hp_ = other.hp_;
      maxHp_ = other.maxHp_;
      atkPower_ = other.atkPower_;
      speed_ = other.speed_;
      totalExp_ = other.totalExp_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public StatInfo Clone() {
      return new StatInfo(this);
    }

    /// <summary>Field number for the "level" field.</summary>
    public const int LevelFieldNumber = 1;
    private int level_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Level {
      get { return level_; }
      set {
        level_ = value;
      }
    }

    /// <summary>Field number for the "hp" field.</summary>
    public const int HpFieldNumber = 2;
    private int hp_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Hp {
      get { return hp_; }
      set {
        hp_ = value;
      }
    }

    /// <summary>Field number for the "maxHp" field.</summary>
    public const int MaxHpFieldNumber = 3;
    private int maxHp_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int MaxHp {
      get { return maxHp_; }
      set {
        maxHp_ = value;
      }
    }

    /// <summary>Field number for the "atkPower" field.</summary>
    public const int AtkPowerFieldNumber = 4;
    private int atkPower_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int AtkPower {
      get { return atkPower_; }
      set {
        atkPower_ = value;
      }
    }

    /// <summary>Field number for the "speed" field.</summary>
    public const int SpeedFieldNumber = 5;
    private float speed_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float Speed {
      get { return speed_; }
      set {
        speed_ = value;
      }
    }

    /// <summary>Field number for the "totalExp" field.</summary>
    public const int TotalExpFieldNumber = 6;
    private int totalExp_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int TotalExp {
      get { return totalExp_; }
      set {
        totalExp_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as StatInfo);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(StatInfo other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Level != other.Level) return false;
      if (Hp != other.Hp) return false;
      if (MaxHp != other.MaxHp) return false;
      if (AtkPower != other.AtkPower) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Speed, other.Speed)) return false;
      if (TotalExp != other.TotalExp) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Level != 0) hash ^= Level.GetHashCode();
      if (Hp != 0) hash ^= Hp.GetHashCode();
      if (MaxHp != 0) hash ^= MaxHp.GetHashCode();
      if (AtkPower != 0) hash ^= AtkPower.GetHashCode();
      if (Speed != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Speed);
      if (TotalExp != 0) hash ^= TotalExp.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Level != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Level);
      }
      if (Hp != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(Hp);
      }
      if (MaxHp != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(MaxHp);
      }
      if (AtkPower != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(AtkPower);
      }
      if (Speed != 0F) {
        output.WriteRawTag(45);
        output.WriteFloat(Speed);
      }
      if (TotalExp != 0) {
        output.WriteRawTag(48);
        output.WriteInt32(TotalExp);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Level != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Level);
      }
      if (Hp != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Hp);
      }
      if (MaxHp != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(MaxHp);
      }
      if (AtkPower != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(AtkPower);
      }
      if (Speed != 0F) {
        size += 1 + 4;
      }
      if (TotalExp != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(TotalExp);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(StatInfo other) {
      if (other == null) {
        return;
      }
      if (other.Level != 0) {
        Level = other.Level;
      }
      if (other.Hp != 0) {
        Hp = other.Hp;
      }
      if (other.MaxHp != 0) {
        MaxHp = other.MaxHp;
      }
      if (other.AtkPower != 0) {
        AtkPower = other.AtkPower;
      }
      if (other.Speed != 0F) {
        Speed = other.Speed;
      }
      if (other.TotalExp != 0) {
        TotalExp = other.TotalExp;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Level = input.ReadInt32();
            break;
          }
          case 16: {
            Hp = input.ReadInt32();
            break;
          }
          case 24: {
            MaxHp = input.ReadInt32();
            break;
          }
          case 32: {
            AtkPower = input.ReadInt32();
            break;
          }
          case 45: {
            Speed = input.ReadFloat();
            break;
          }
          case 48: {
            TotalExp = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  public sealed partial class EntityInfo : pb::IMessage<EntityInfo> {
    private static readonly pb::MessageParser<EntityInfo> _parser = new pb::MessageParser<EntityInfo>(() => new EntityInfo());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<EntityInfo> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Protobuf.Protocol.ProtocolReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public EntityInfo() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public EntityInfo(EntityInfo other) : this() {
      id_ = other.id_;
      name_ = other.name_;
      type_ = other.type_;
      transform_ = other.transform_ != null ? other.transform_.Clone() : null;
      stat_ = other.stat_ != null ? other.stat_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public EntityInfo Clone() {
      return new EntityInfo(this);
    }

    /// <summary>Field number for the "id" field.</summary>
    public const int IdFieldNumber = 1;
    private int id_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Id {
      get { return id_; }
      set {
        id_ = value;
      }
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 2;
    private string name_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "type" field.</summary>
    public const int TypeFieldNumber = 3;
    private global::Google.Protobuf.Protocol.EntityType type_ = global::Google.Protobuf.Protocol.EntityType.None;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.Protocol.EntityType Type {
      get { return type_; }
      set {
        type_ = value;
      }
    }

    /// <summary>Field number for the "transform" field.</summary>
    public const int TransformFieldNumber = 4;
    private global::Google.Protobuf.Protocol.TransformInfo transform_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.Protocol.TransformInfo Transform {
      get { return transform_; }
      set {
        transform_ = value;
      }
    }

    /// <summary>Field number for the "stat" field.</summary>
    public const int StatFieldNumber = 5;
    private global::Google.Protobuf.Protocol.StatInfo stat_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.Protocol.StatInfo Stat {
      get { return stat_; }
      set {
        stat_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as EntityInfo);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(EntityInfo other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Id != other.Id) return false;
      if (Name != other.Name) return false;
      if (Type != other.Type) return false;
      if (!object.Equals(Transform, other.Transform)) return false;
      if (!object.Equals(Stat, other.Stat)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Id != 0) hash ^= Id.GetHashCode();
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (Type != global::Google.Protobuf.Protocol.EntityType.None) hash ^= Type.GetHashCode();
      if (transform_ != null) hash ^= Transform.GetHashCode();
      if (stat_ != null) hash ^= Stat.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Id != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Id);
      }
      if (Name.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Name);
      }
      if (Type != global::Google.Protobuf.Protocol.EntityType.None) {
        output.WriteRawTag(24);
        output.WriteEnum((int) Type);
      }
      if (transform_ != null) {
        output.WriteRawTag(34);
        output.WriteMessage(Transform);
      }
      if (stat_ != null) {
        output.WriteRawTag(42);
        output.WriteMessage(Stat);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Id != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Id);
      }
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (Type != global::Google.Protobuf.Protocol.EntityType.None) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Type);
      }
      if (transform_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Transform);
      }
      if (stat_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Stat);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(EntityInfo other) {
      if (other == null) {
        return;
      }
      if (other.Id != 0) {
        Id = other.Id;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.Type != global::Google.Protobuf.Protocol.EntityType.None) {
        Type = other.Type;
      }
      if (other.transform_ != null) {
        if (transform_ == null) {
          Transform = new global::Google.Protobuf.Protocol.TransformInfo();
        }
        Transform.MergeFrom(other.Transform);
      }
      if (other.stat_ != null) {
        if (stat_ == null) {
          Stat = new global::Google.Protobuf.Protocol.StatInfo();
        }
        Stat.MergeFrom(other.Stat);
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Id = input.ReadInt32();
            break;
          }
          case 18: {
            Name = input.ReadString();
            break;
          }
          case 24: {
            Type = (global::Google.Protobuf.Protocol.EntityType) input.ReadEnum();
            break;
          }
          case 34: {
            if (transform_ == null) {
              Transform = new global::Google.Protobuf.Protocol.TransformInfo();
            }
            input.ReadMessage(Transform);
            break;
          }
          case 42: {
            if (stat_ == null) {
              Stat = new global::Google.Protobuf.Protocol.StatInfo();
            }
            input.ReadMessage(Stat);
            break;
          }
        }
      }
    }

  }

  public sealed partial class S_ConnectedToServer : pb::IMessage<S_ConnectedToServer> {
    private static readonly pb::MessageParser<S_ConnectedToServer> _parser = new pb::MessageParser<S_ConnectedToServer>(() => new S_ConnectedToServer());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<S_ConnectedToServer> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Protobuf.Protocol.ProtocolReflection.Descriptor.MessageTypes[4]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public S_ConnectedToServer() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public S_ConnectedToServer(S_ConnectedToServer other) : this() {
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public S_ConnectedToServer Clone() {
      return new S_ConnectedToServer(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as S_ConnectedToServer);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(S_ConnectedToServer other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(S_ConnectedToServer other) {
      if (other == null) {
        return;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
