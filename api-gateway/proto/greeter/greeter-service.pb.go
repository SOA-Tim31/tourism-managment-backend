// Code generated by protoc-gen-go. DO NOT EDIT.
// versions:
// 	protoc-gen-go v1.34.1
// 	protoc        v5.27.0--rc3
// source: greeter/greeter-service.proto

package greeter

import (
	_ "google.golang.org/genproto/googleapis/api/annotations"
	protoreflect "google.golang.org/protobuf/reflect/protoreflect"
	protoimpl "google.golang.org/protobuf/runtime/protoimpl"
	reflect "reflect"
	sync "sync"
)

const (
	// Verify that this generated code is sufficiently up-to-date.
	_ = protoimpl.EnforceVersion(20 - protoimpl.MinVersion)
	// Verify that runtime/protoimpl is sufficiently up-to-date.
	_ = protoimpl.EnforceVersion(protoimpl.MaxVersion - 20)
)

type UserRole int32

const (
	UserRole_Administrator UserRole = 0
	UserRole_Tourist       UserRole = 1
	UserRole_Author        UserRole = 2
)

// Enum value maps for UserRole.
var (
	UserRole_name = map[int32]string{
		0: "Administrator",
		1: "Tourist",
		2: "Author",
	}
	UserRole_value = map[string]int32{
		"Administrator": 0,
		"Tourist":       1,
		"Author":        2,
	}
)

func (x UserRole) Enum() *UserRole {
	p := new(UserRole)
	*p = x
	return p
}

func (x UserRole) String() string {
	return protoimpl.X.EnumStringOf(x.Descriptor(), protoreflect.EnumNumber(x))
}

func (UserRole) Descriptor() protoreflect.EnumDescriptor {
	return file_greeter_greeter_service_proto_enumTypes[0].Descriptor()
}

func (UserRole) Type() protoreflect.EnumType {
	return &file_greeter_greeter_service_proto_enumTypes[0]
}

func (x UserRole) Number() protoreflect.EnumNumber {
	return protoreflect.EnumNumber(x)
}

// Deprecated: Use UserRole.Descriptor instead.
func (UserRole) EnumDescriptor() ([]byte, []int) {
	return file_greeter_greeter_service_proto_rawDescGZIP(), []int{0}
}

type User struct {
	state         protoimpl.MessageState
	sizeCache     protoimpl.SizeCache
	unknownFields protoimpl.UnknownFields

	Id                uint64   `protobuf:"varint,1,opt,name=Id,proto3" json:"Id,omitempty"`
	Username          string   `protobuf:"bytes,5,opt,name=Username,proto3" json:"Username,omitempty"`
	Password          string   `protobuf:"bytes,6,opt,name=Password,proto3" json:"Password,omitempty"`
	Role              UserRole `protobuf:"varint,7,opt,name=Role,proto3,enum=UserRole" json:"Role,omitempty"`
	IsActive          bool     `protobuf:"varint,8,opt,name=IsActive,proto3" json:"IsActive,omitempty"`
	VerificationToken string   `protobuf:"bytes,9,opt,name=VerificationToken,proto3" json:"VerificationToken,omitempty"`
}

func (x *User) Reset() {
	*x = User{}
	if protoimpl.UnsafeEnabled {
		mi := &file_greeter_greeter_service_proto_msgTypes[0]
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		ms.StoreMessageInfo(mi)
	}
}

func (x *User) String() string {
	return protoimpl.X.MessageStringOf(x)
}

func (*User) ProtoMessage() {}

func (x *User) ProtoReflect() protoreflect.Message {
	mi := &file_greeter_greeter_service_proto_msgTypes[0]
	if protoimpl.UnsafeEnabled && x != nil {
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		if ms.LoadMessageInfo() == nil {
			ms.StoreMessageInfo(mi)
		}
		return ms
	}
	return mi.MessageOf(x)
}

// Deprecated: Use User.ProtoReflect.Descriptor instead.
func (*User) Descriptor() ([]byte, []int) {
	return file_greeter_greeter_service_proto_rawDescGZIP(), []int{0}
}

func (x *User) GetId() uint64 {
	if x != nil {
		return x.Id
	}
	return 0
}

func (x *User) GetUsername() string {
	if x != nil {
		return x.Username
	}
	return ""
}

func (x *User) GetPassword() string {
	if x != nil {
		return x.Password
	}
	return ""
}

func (x *User) GetRole() UserRole {
	if x != nil {
		return x.Role
	}
	return UserRole_Administrator
}

func (x *User) GetIsActive() bool {
	if x != nil {
		return x.IsActive
	}
	return false
}

func (x *User) GetVerificationToken() string {
	if x != nil {
		return x.VerificationToken
	}
	return ""
}

type Person struct {
	state         protoimpl.MessageState
	sizeCache     protoimpl.SizeCache
	unknownFields protoimpl.UnknownFields

	Id           uint64 `protobuf:"varint,1,opt,name=Id,proto3" json:"Id,omitempty"`
	UserId       uint64 `protobuf:"varint,2,opt,name=UserId,proto3" json:"UserId,omitempty"`
	Name         string `protobuf:"bytes,3,opt,name=Name,proto3" json:"Name,omitempty"`
	Surname      string `protobuf:"bytes,4,opt,name=Surname,proto3" json:"Surname,omitempty"`
	Email        string `protobuf:"bytes,5,opt,name=Email,proto3" json:"Email,omitempty"`
	ProfileImage string `protobuf:"bytes,6,opt,name=ProfileImage,proto3" json:"ProfileImage,omitempty"`
	Bio          string `protobuf:"bytes,7,opt,name=Bio,proto3" json:"Bio,omitempty"`
	Quote        string `protobuf:"bytes,8,opt,name=Quote,proto3" json:"Quote,omitempty"`
}

func (x *Person) Reset() {
	*x = Person{}
	if protoimpl.UnsafeEnabled {
		mi := &file_greeter_greeter_service_proto_msgTypes[1]
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		ms.StoreMessageInfo(mi)
	}
}

func (x *Person) String() string {
	return protoimpl.X.MessageStringOf(x)
}

func (*Person) ProtoMessage() {}

func (x *Person) ProtoReflect() protoreflect.Message {
	mi := &file_greeter_greeter_service_proto_msgTypes[1]
	if protoimpl.UnsafeEnabled && x != nil {
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		if ms.LoadMessageInfo() == nil {
			ms.StoreMessageInfo(mi)
		}
		return ms
	}
	return mi.MessageOf(x)
}

// Deprecated: Use Person.ProtoReflect.Descriptor instead.
func (*Person) Descriptor() ([]byte, []int) {
	return file_greeter_greeter_service_proto_rawDescGZIP(), []int{1}
}

func (x *Person) GetId() uint64 {
	if x != nil {
		return x.Id
	}
	return 0
}

func (x *Person) GetUserId() uint64 {
	if x != nil {
		return x.UserId
	}
	return 0
}

func (x *Person) GetName() string {
	if x != nil {
		return x.Name
	}
	return ""
}

func (x *Person) GetSurname() string {
	if x != nil {
		return x.Surname
	}
	return ""
}

func (x *Person) GetEmail() string {
	if x != nil {
		return x.Email
	}
	return ""
}

func (x *Person) GetProfileImage() string {
	if x != nil {
		return x.ProfileImage
	}
	return ""
}

func (x *Person) GetBio() string {
	if x != nil {
		return x.Bio
	}
	return ""
}

func (x *Person) GetQuote() string {
	if x != nil {
		return x.Quote
	}
	return ""
}

type RegistrationRequest struct {
	state         protoimpl.MessageState
	sizeCache     protoimpl.SizeCache
	unknownFields protoimpl.UnknownFields

	Username string `protobuf:"bytes,1,opt,name=username,proto3" json:"username,omitempty"` // Username polje
	Password string `protobuf:"bytes,2,opt,name=password,proto3" json:"password,omitempty"` // Password polje
	Email    string `protobuf:"bytes,3,opt,name=email,proto3" json:"email,omitempty"`       // Email polje
	Name     string `protobuf:"bytes,4,opt,name=name,proto3" json:"name,omitempty"`         // Name polje
	Surname  string `protobuf:"bytes,5,opt,name=surname,proto3" json:"surname,omitempty"`   // Surname polje
	Role     string `protobuf:"bytes,6,opt,name=role,proto3" json:"role,omitempty"`         // Role polje
}

func (x *RegistrationRequest) Reset() {
	*x = RegistrationRequest{}
	if protoimpl.UnsafeEnabled {
		mi := &file_greeter_greeter_service_proto_msgTypes[2]
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		ms.StoreMessageInfo(mi)
	}
}

func (x *RegistrationRequest) String() string {
	return protoimpl.X.MessageStringOf(x)
}

func (*RegistrationRequest) ProtoMessage() {}

func (x *RegistrationRequest) ProtoReflect() protoreflect.Message {
	mi := &file_greeter_greeter_service_proto_msgTypes[2]
	if protoimpl.UnsafeEnabled && x != nil {
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		if ms.LoadMessageInfo() == nil {
			ms.StoreMessageInfo(mi)
		}
		return ms
	}
	return mi.MessageOf(x)
}

// Deprecated: Use RegistrationRequest.ProtoReflect.Descriptor instead.
func (*RegistrationRequest) Descriptor() ([]byte, []int) {
	return file_greeter_greeter_service_proto_rawDescGZIP(), []int{2}
}

func (x *RegistrationRequest) GetUsername() string {
	if x != nil {
		return x.Username
	}
	return ""
}

func (x *RegistrationRequest) GetPassword() string {
	if x != nil {
		return x.Password
	}
	return ""
}

func (x *RegistrationRequest) GetEmail() string {
	if x != nil {
		return x.Email
	}
	return ""
}

func (x *RegistrationRequest) GetName() string {
	if x != nil {
		return x.Name
	}
	return ""
}

func (x *RegistrationRequest) GetSurname() string {
	if x != nil {
		return x.Surname
	}
	return ""
}

func (x *RegistrationRequest) GetRole() string {
	if x != nil {
		return x.Role
	}
	return ""
}

type RegistrationResponse struct {
	state         protoimpl.MessageState
	sizeCache     protoimpl.SizeCache
	unknownFields protoimpl.UnknownFields

	Message string `protobuf:"bytes,1,opt,name=message,proto3" json:"message,omitempty"`
}

func (x *RegistrationResponse) Reset() {
	*x = RegistrationResponse{}
	if protoimpl.UnsafeEnabled {
		mi := &file_greeter_greeter_service_proto_msgTypes[3]
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		ms.StoreMessageInfo(mi)
	}
}

func (x *RegistrationResponse) String() string {
	return protoimpl.X.MessageStringOf(x)
}

func (*RegistrationResponse) ProtoMessage() {}

func (x *RegistrationResponse) ProtoReflect() protoreflect.Message {
	mi := &file_greeter_greeter_service_proto_msgTypes[3]
	if protoimpl.UnsafeEnabled && x != nil {
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		if ms.LoadMessageInfo() == nil {
			ms.StoreMessageInfo(mi)
		}
		return ms
	}
	return mi.MessageOf(x)
}

// Deprecated: Use RegistrationResponse.ProtoReflect.Descriptor instead.
func (*RegistrationResponse) Descriptor() ([]byte, []int) {
	return file_greeter_greeter_service_proto_rawDescGZIP(), []int{3}
}

func (x *RegistrationResponse) GetMessage() string {
	if x != nil {
		return x.Message
	}
	return ""
}

type LoginRequest struct {
	state         protoimpl.MessageState
	sizeCache     protoimpl.SizeCache
	unknownFields protoimpl.UnknownFields

	Username string `protobuf:"bytes,1,opt,name=username,proto3" json:"username,omitempty"`
	Password string `protobuf:"bytes,2,opt,name=password,proto3" json:"password,omitempty"`
}

func (x *LoginRequest) Reset() {
	*x = LoginRequest{}
	if protoimpl.UnsafeEnabled {
		mi := &file_greeter_greeter_service_proto_msgTypes[4]
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		ms.StoreMessageInfo(mi)
	}
}

func (x *LoginRequest) String() string {
	return protoimpl.X.MessageStringOf(x)
}

func (*LoginRequest) ProtoMessage() {}

func (x *LoginRequest) ProtoReflect() protoreflect.Message {
	mi := &file_greeter_greeter_service_proto_msgTypes[4]
	if protoimpl.UnsafeEnabled && x != nil {
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		if ms.LoadMessageInfo() == nil {
			ms.StoreMessageInfo(mi)
		}
		return ms
	}
	return mi.MessageOf(x)
}

// Deprecated: Use LoginRequest.ProtoReflect.Descriptor instead.
func (*LoginRequest) Descriptor() ([]byte, []int) {
	return file_greeter_greeter_service_proto_rawDescGZIP(), []int{4}
}

func (x *LoginRequest) GetUsername() string {
	if x != nil {
		return x.Username
	}
	return ""
}

func (x *LoginRequest) GetPassword() string {
	if x != nil {
		return x.Password
	}
	return ""
}

type LoginResponse struct {
	state         protoimpl.MessageState
	sizeCache     protoimpl.SizeCache
	unknownFields protoimpl.UnknownFields

	Id          uint64 `protobuf:"varint,1,opt,name=id,proto3" json:"id,omitempty"`
	AccessToken string `protobuf:"bytes,2,opt,name=access_token,json=accessToken,proto3" json:"access_token,omitempty"`
}

func (x *LoginResponse) Reset() {
	*x = LoginResponse{}
	if protoimpl.UnsafeEnabled {
		mi := &file_greeter_greeter_service_proto_msgTypes[5]
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		ms.StoreMessageInfo(mi)
	}
}

func (x *LoginResponse) String() string {
	return protoimpl.X.MessageStringOf(x)
}

func (*LoginResponse) ProtoMessage() {}

func (x *LoginResponse) ProtoReflect() protoreflect.Message {
	mi := &file_greeter_greeter_service_proto_msgTypes[5]
	if protoimpl.UnsafeEnabled && x != nil {
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		if ms.LoadMessageInfo() == nil {
			ms.StoreMessageInfo(mi)
		}
		return ms
	}
	return mi.MessageOf(x)
}

// Deprecated: Use LoginResponse.ProtoReflect.Descriptor instead.
func (*LoginResponse) Descriptor() ([]byte, []int) {
	return file_greeter_greeter_service_proto_rawDescGZIP(), []int{5}
}

func (x *LoginResponse) GetId() uint64 {
	if x != nil {
		return x.Id
	}
	return 0
}

func (x *LoginResponse) GetAccessToken() string {
	if x != nil {
		return x.AccessToken
	}
	return ""
}

type AccountDto struct {
	state         protoimpl.MessageState
	sizeCache     protoimpl.SizeCache
	unknownFields protoimpl.UnknownFields

	UserId   uint64 `protobuf:"varint,1,opt,name=UserId,proto3" json:"UserId,omitempty"`
	Username string `protobuf:"bytes,2,opt,name=Username,proto3" json:"Username,omitempty"`
	Password string `protobuf:"bytes,3,opt,name=Password,proto3" json:"Password,omitempty"`
	Email    string `protobuf:"bytes,4,opt,name=Email,proto3" json:"Email,omitempty"`
	Role     string `protobuf:"bytes,5,opt,name=Role,proto3" json:"Role,omitempty"`
	IsActive bool   `protobuf:"varint,6,opt,name=IsActive,proto3" json:"IsActive,omitempty"`
}

func (x *AccountDto) Reset() {
	*x = AccountDto{}
	if protoimpl.UnsafeEnabled {
		mi := &file_greeter_greeter_service_proto_msgTypes[6]
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		ms.StoreMessageInfo(mi)
	}
}

func (x *AccountDto) String() string {
	return protoimpl.X.MessageStringOf(x)
}

func (*AccountDto) ProtoMessage() {}

func (x *AccountDto) ProtoReflect() protoreflect.Message {
	mi := &file_greeter_greeter_service_proto_msgTypes[6]
	if protoimpl.UnsafeEnabled && x != nil {
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		if ms.LoadMessageInfo() == nil {
			ms.StoreMessageInfo(mi)
		}
		return ms
	}
	return mi.MessageOf(x)
}

// Deprecated: Use AccountDto.ProtoReflect.Descriptor instead.
func (*AccountDto) Descriptor() ([]byte, []int) {
	return file_greeter_greeter_service_proto_rawDescGZIP(), []int{6}
}

func (x *AccountDto) GetUserId() uint64 {
	if x != nil {
		return x.UserId
	}
	return 0
}

func (x *AccountDto) GetUsername() string {
	if x != nil {
		return x.Username
	}
	return ""
}

func (x *AccountDto) GetPassword() string {
	if x != nil {
		return x.Password
	}
	return ""
}

func (x *AccountDto) GetEmail() string {
	if x != nil {
		return x.Email
	}
	return ""
}

func (x *AccountDto) GetRole() string {
	if x != nil {
		return x.Role
	}
	return ""
}

func (x *AccountDto) GetIsActive() bool {
	if x != nil {
		return x.IsActive
	}
	return false
}

type FindAllRequest struct {
	state         protoimpl.MessageState
	sizeCache     protoimpl.SizeCache
	unknownFields protoimpl.UnknownFields
}

func (x *FindAllRequest) Reset() {
	*x = FindAllRequest{}
	if protoimpl.UnsafeEnabled {
		mi := &file_greeter_greeter_service_proto_msgTypes[7]
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		ms.StoreMessageInfo(mi)
	}
}

func (x *FindAllRequest) String() string {
	return protoimpl.X.MessageStringOf(x)
}

func (*FindAllRequest) ProtoMessage() {}

func (x *FindAllRequest) ProtoReflect() protoreflect.Message {
	mi := &file_greeter_greeter_service_proto_msgTypes[7]
	if protoimpl.UnsafeEnabled && x != nil {
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		if ms.LoadMessageInfo() == nil {
			ms.StoreMessageInfo(mi)
		}
		return ms
	}
	return mi.MessageOf(x)
}

// Deprecated: Use FindAllRequest.ProtoReflect.Descriptor instead.
func (*FindAllRequest) Descriptor() ([]byte, []int) {
	return file_greeter_greeter_service_proto_rawDescGZIP(), []int{7}
}

type FindAllResponse struct {
	state         protoimpl.MessageState
	sizeCache     protoimpl.SizeCache
	unknownFields protoimpl.UnknownFields

	Accounts []*AccountDto `protobuf:"bytes,1,rep,name=accounts,proto3" json:"accounts,omitempty"`
}

func (x *FindAllResponse) Reset() {
	*x = FindAllResponse{}
	if protoimpl.UnsafeEnabled {
		mi := &file_greeter_greeter_service_proto_msgTypes[8]
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		ms.StoreMessageInfo(mi)
	}
}

func (x *FindAllResponse) String() string {
	return protoimpl.X.MessageStringOf(x)
}

func (*FindAllResponse) ProtoMessage() {}

func (x *FindAllResponse) ProtoReflect() protoreflect.Message {
	mi := &file_greeter_greeter_service_proto_msgTypes[8]
	if protoimpl.UnsafeEnabled && x != nil {
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		if ms.LoadMessageInfo() == nil {
			ms.StoreMessageInfo(mi)
		}
		return ms
	}
	return mi.MessageOf(x)
}

// Deprecated: Use FindAllResponse.ProtoReflect.Descriptor instead.
func (*FindAllResponse) Descriptor() ([]byte, []int) {
	return file_greeter_greeter_service_proto_rawDescGZIP(), []int{8}
}

func (x *FindAllResponse) GetAccounts() []*AccountDto {
	if x != nil {
		return x.Accounts
	}
	return nil
}

type GetProfileRequest struct {
	state         protoimpl.MessageState
	sizeCache     protoimpl.SizeCache
	unknownFields protoimpl.UnknownFields

	Id string `protobuf:"bytes,1,opt,name=id,proto3" json:"id,omitempty"`
}

func (x *GetProfileRequest) Reset() {
	*x = GetProfileRequest{}
	if protoimpl.UnsafeEnabled {
		mi := &file_greeter_greeter_service_proto_msgTypes[9]
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		ms.StoreMessageInfo(mi)
	}
}

func (x *GetProfileRequest) String() string {
	return protoimpl.X.MessageStringOf(x)
}

func (*GetProfileRequest) ProtoMessage() {}

func (x *GetProfileRequest) ProtoReflect() protoreflect.Message {
	mi := &file_greeter_greeter_service_proto_msgTypes[9]
	if protoimpl.UnsafeEnabled && x != nil {
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		if ms.LoadMessageInfo() == nil {
			ms.StoreMessageInfo(mi)
		}
		return ms
	}
	return mi.MessageOf(x)
}

// Deprecated: Use GetProfileRequest.ProtoReflect.Descriptor instead.
func (*GetProfileRequest) Descriptor() ([]byte, []int) {
	return file_greeter_greeter_service_proto_rawDescGZIP(), []int{9}
}

func (x *GetProfileRequest) GetId() string {
	if x != nil {
		return x.Id
	}
	return ""
}

type GetProfileResponse struct {
	state         protoimpl.MessageState
	sizeCache     protoimpl.SizeCache
	unknownFields protoimpl.UnknownFields

	Person *Person `protobuf:"bytes,1,opt,name=person,proto3" json:"person,omitempty"`
}

func (x *GetProfileResponse) Reset() {
	*x = GetProfileResponse{}
	if protoimpl.UnsafeEnabled {
		mi := &file_greeter_greeter_service_proto_msgTypes[10]
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		ms.StoreMessageInfo(mi)
	}
}

func (x *GetProfileResponse) String() string {
	return protoimpl.X.MessageStringOf(x)
}

func (*GetProfileResponse) ProtoMessage() {}

func (x *GetProfileResponse) ProtoReflect() protoreflect.Message {
	mi := &file_greeter_greeter_service_proto_msgTypes[10]
	if protoimpl.UnsafeEnabled && x != nil {
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		if ms.LoadMessageInfo() == nil {
			ms.StoreMessageInfo(mi)
		}
		return ms
	}
	return mi.MessageOf(x)
}

// Deprecated: Use GetProfileResponse.ProtoReflect.Descriptor instead.
func (*GetProfileResponse) Descriptor() ([]byte, []int) {
	return file_greeter_greeter_service_proto_rawDescGZIP(), []int{10}
}

func (x *GetProfileResponse) GetPerson() *Person {
	if x != nil {
		return x.Person
	}
	return nil
}

type Request struct {
	state         protoimpl.MessageState
	sizeCache     protoimpl.SizeCache
	unknownFields protoimpl.UnknownFields

	Name string `protobuf:"bytes,1,opt,name=name,proto3" json:"name,omitempty"`
}

func (x *Request) Reset() {
	*x = Request{}
	if protoimpl.UnsafeEnabled {
		mi := &file_greeter_greeter_service_proto_msgTypes[11]
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		ms.StoreMessageInfo(mi)
	}
}

func (x *Request) String() string {
	return protoimpl.X.MessageStringOf(x)
}

func (*Request) ProtoMessage() {}

func (x *Request) ProtoReflect() protoreflect.Message {
	mi := &file_greeter_greeter_service_proto_msgTypes[11]
	if protoimpl.UnsafeEnabled && x != nil {
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		if ms.LoadMessageInfo() == nil {
			ms.StoreMessageInfo(mi)
		}
		return ms
	}
	return mi.MessageOf(x)
}

// Deprecated: Use Request.ProtoReflect.Descriptor instead.
func (*Request) Descriptor() ([]byte, []int) {
	return file_greeter_greeter_service_proto_rawDescGZIP(), []int{11}
}

func (x *Request) GetName() string {
	if x != nil {
		return x.Name
	}
	return ""
}

type Response struct {
	state         protoimpl.MessageState
	sizeCache     protoimpl.SizeCache
	unknownFields protoimpl.UnknownFields

	Greeting string `protobuf:"bytes,2,opt,name=greeting,proto3" json:"greeting,omitempty"`
}

func (x *Response) Reset() {
	*x = Response{}
	if protoimpl.UnsafeEnabled {
		mi := &file_greeter_greeter_service_proto_msgTypes[12]
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		ms.StoreMessageInfo(mi)
	}
}

func (x *Response) String() string {
	return protoimpl.X.MessageStringOf(x)
}

func (*Response) ProtoMessage() {}

func (x *Response) ProtoReflect() protoreflect.Message {
	mi := &file_greeter_greeter_service_proto_msgTypes[12]
	if protoimpl.UnsafeEnabled && x != nil {
		ms := protoimpl.X.MessageStateOf(protoimpl.Pointer(x))
		if ms.LoadMessageInfo() == nil {
			ms.StoreMessageInfo(mi)
		}
		return ms
	}
	return mi.MessageOf(x)
}

// Deprecated: Use Response.ProtoReflect.Descriptor instead.
func (*Response) Descriptor() ([]byte, []int) {
	return file_greeter_greeter_service_proto_rawDescGZIP(), []int{12}
}

func (x *Response) GetGreeting() string {
	if x != nil {
		return x.Greeting
	}
	return ""
}

var File_greeter_greeter_service_proto protoreflect.FileDescriptor

var file_greeter_greeter_service_proto_rawDesc = []byte{
	0x0a, 0x1d, 0x67, 0x72, 0x65, 0x65, 0x74, 0x65, 0x72, 0x2f, 0x67, 0x72, 0x65, 0x65, 0x74, 0x65,
	0x72, 0x2d, 0x73, 0x65, 0x72, 0x76, 0x69, 0x63, 0x65, 0x2e, 0x70, 0x72, 0x6f, 0x74, 0x6f, 0x1a,
	0x1c, 0x67, 0x6f, 0x6f, 0x67, 0x6c, 0x65, 0x2f, 0x61, 0x70, 0x69, 0x2f, 0x61, 0x6e, 0x6e, 0x6f,
	0x74, 0x61, 0x74, 0x69, 0x6f, 0x6e, 0x73, 0x2e, 0x70, 0x72, 0x6f, 0x74, 0x6f, 0x22, 0xb7, 0x01,
	0x0a, 0x04, 0x55, 0x73, 0x65, 0x72, 0x12, 0x0e, 0x0a, 0x02, 0x49, 0x64, 0x18, 0x01, 0x20, 0x01,
	0x28, 0x04, 0x52, 0x02, 0x49, 0x64, 0x12, 0x1a, 0x0a, 0x08, 0x55, 0x73, 0x65, 0x72, 0x6e, 0x61,
	0x6d, 0x65, 0x18, 0x05, 0x20, 0x01, 0x28, 0x09, 0x52, 0x08, 0x55, 0x73, 0x65, 0x72, 0x6e, 0x61,
	0x6d, 0x65, 0x12, 0x1a, 0x0a, 0x08, 0x50, 0x61, 0x73, 0x73, 0x77, 0x6f, 0x72, 0x64, 0x18, 0x06,
	0x20, 0x01, 0x28, 0x09, 0x52, 0x08, 0x50, 0x61, 0x73, 0x73, 0x77, 0x6f, 0x72, 0x64, 0x12, 0x1d,
	0x0a, 0x04, 0x52, 0x6f, 0x6c, 0x65, 0x18, 0x07, 0x20, 0x01, 0x28, 0x0e, 0x32, 0x09, 0x2e, 0x55,
	0x73, 0x65, 0x72, 0x52, 0x6f, 0x6c, 0x65, 0x52, 0x04, 0x52, 0x6f, 0x6c, 0x65, 0x12, 0x1a, 0x0a,
	0x08, 0x49, 0x73, 0x41, 0x63, 0x74, 0x69, 0x76, 0x65, 0x18, 0x08, 0x20, 0x01, 0x28, 0x08, 0x52,
	0x08, 0x49, 0x73, 0x41, 0x63, 0x74, 0x69, 0x76, 0x65, 0x12, 0x2c, 0x0a, 0x11, 0x56, 0x65, 0x72,
	0x69, 0x66, 0x69, 0x63, 0x61, 0x74, 0x69, 0x6f, 0x6e, 0x54, 0x6f, 0x6b, 0x65, 0x6e, 0x18, 0x09,
	0x20, 0x01, 0x28, 0x09, 0x52, 0x11, 0x56, 0x65, 0x72, 0x69, 0x66, 0x69, 0x63, 0x61, 0x74, 0x69,
	0x6f, 0x6e, 0x54, 0x6f, 0x6b, 0x65, 0x6e, 0x22, 0xc0, 0x01, 0x0a, 0x06, 0x50, 0x65, 0x72, 0x73,
	0x6f, 0x6e, 0x12, 0x0e, 0x0a, 0x02, 0x49, 0x64, 0x18, 0x01, 0x20, 0x01, 0x28, 0x04, 0x52, 0x02,
	0x49, 0x64, 0x12, 0x16, 0x0a, 0x06, 0x55, 0x73, 0x65, 0x72, 0x49, 0x64, 0x18, 0x02, 0x20, 0x01,
	0x28, 0x04, 0x52, 0x06, 0x55, 0x73, 0x65, 0x72, 0x49, 0x64, 0x12, 0x12, 0x0a, 0x04, 0x4e, 0x61,
	0x6d, 0x65, 0x18, 0x03, 0x20, 0x01, 0x28, 0x09, 0x52, 0x04, 0x4e, 0x61, 0x6d, 0x65, 0x12, 0x18,
	0x0a, 0x07, 0x53, 0x75, 0x72, 0x6e, 0x61, 0x6d, 0x65, 0x18, 0x04, 0x20, 0x01, 0x28, 0x09, 0x52,
	0x07, 0x53, 0x75, 0x72, 0x6e, 0x61, 0x6d, 0x65, 0x12, 0x14, 0x0a, 0x05, 0x45, 0x6d, 0x61, 0x69,
	0x6c, 0x18, 0x05, 0x20, 0x01, 0x28, 0x09, 0x52, 0x05, 0x45, 0x6d, 0x61, 0x69, 0x6c, 0x12, 0x22,
	0x0a, 0x0c, 0x50, 0x72, 0x6f, 0x66, 0x69, 0x6c, 0x65, 0x49, 0x6d, 0x61, 0x67, 0x65, 0x18, 0x06,
	0x20, 0x01, 0x28, 0x09, 0x52, 0x0c, 0x50, 0x72, 0x6f, 0x66, 0x69, 0x6c, 0x65, 0x49, 0x6d, 0x61,
	0x67, 0x65, 0x12, 0x10, 0x0a, 0x03, 0x42, 0x69, 0x6f, 0x18, 0x07, 0x20, 0x01, 0x28, 0x09, 0x52,
	0x03, 0x42, 0x69, 0x6f, 0x12, 0x14, 0x0a, 0x05, 0x51, 0x75, 0x6f, 0x74, 0x65, 0x18, 0x08, 0x20,
	0x01, 0x28, 0x09, 0x52, 0x05, 0x51, 0x75, 0x6f, 0x74, 0x65, 0x22, 0xa5, 0x01, 0x0a, 0x13, 0x52,
	0x65, 0x67, 0x69, 0x73, 0x74, 0x72, 0x61, 0x74, 0x69, 0x6f, 0x6e, 0x52, 0x65, 0x71, 0x75, 0x65,
	0x73, 0x74, 0x12, 0x1a, 0x0a, 0x08, 0x75, 0x73, 0x65, 0x72, 0x6e, 0x61, 0x6d, 0x65, 0x18, 0x01,
	0x20, 0x01, 0x28, 0x09, 0x52, 0x08, 0x75, 0x73, 0x65, 0x72, 0x6e, 0x61, 0x6d, 0x65, 0x12, 0x1a,
	0x0a, 0x08, 0x70, 0x61, 0x73, 0x73, 0x77, 0x6f, 0x72, 0x64, 0x18, 0x02, 0x20, 0x01, 0x28, 0x09,
	0x52, 0x08, 0x70, 0x61, 0x73, 0x73, 0x77, 0x6f, 0x72, 0x64, 0x12, 0x14, 0x0a, 0x05, 0x65, 0x6d,
	0x61, 0x69, 0x6c, 0x18, 0x03, 0x20, 0x01, 0x28, 0x09, 0x52, 0x05, 0x65, 0x6d, 0x61, 0x69, 0x6c,
	0x12, 0x12, 0x0a, 0x04, 0x6e, 0x61, 0x6d, 0x65, 0x18, 0x04, 0x20, 0x01, 0x28, 0x09, 0x52, 0x04,
	0x6e, 0x61, 0x6d, 0x65, 0x12, 0x18, 0x0a, 0x07, 0x73, 0x75, 0x72, 0x6e, 0x61, 0x6d, 0x65, 0x18,
	0x05, 0x20, 0x01, 0x28, 0x09, 0x52, 0x07, 0x73, 0x75, 0x72, 0x6e, 0x61, 0x6d, 0x65, 0x12, 0x12,
	0x0a, 0x04, 0x72, 0x6f, 0x6c, 0x65, 0x18, 0x06, 0x20, 0x01, 0x28, 0x09, 0x52, 0x04, 0x72, 0x6f,
	0x6c, 0x65, 0x22, 0x30, 0x0a, 0x14, 0x52, 0x65, 0x67, 0x69, 0x73, 0x74, 0x72, 0x61, 0x74, 0x69,
	0x6f, 0x6e, 0x52, 0x65, 0x73, 0x70, 0x6f, 0x6e, 0x73, 0x65, 0x12, 0x18, 0x0a, 0x07, 0x6d, 0x65,
	0x73, 0x73, 0x61, 0x67, 0x65, 0x18, 0x01, 0x20, 0x01, 0x28, 0x09, 0x52, 0x07, 0x6d, 0x65, 0x73,
	0x73, 0x61, 0x67, 0x65, 0x22, 0x46, 0x0a, 0x0c, 0x4c, 0x6f, 0x67, 0x69, 0x6e, 0x52, 0x65, 0x71,
	0x75, 0x65, 0x73, 0x74, 0x12, 0x1a, 0x0a, 0x08, 0x75, 0x73, 0x65, 0x72, 0x6e, 0x61, 0x6d, 0x65,
	0x18, 0x01, 0x20, 0x01, 0x28, 0x09, 0x52, 0x08, 0x75, 0x73, 0x65, 0x72, 0x6e, 0x61, 0x6d, 0x65,
	0x12, 0x1a, 0x0a, 0x08, 0x70, 0x61, 0x73, 0x73, 0x77, 0x6f, 0x72, 0x64, 0x18, 0x02, 0x20, 0x01,
	0x28, 0x09, 0x52, 0x08, 0x70, 0x61, 0x73, 0x73, 0x77, 0x6f, 0x72, 0x64, 0x22, 0x42, 0x0a, 0x0d,
	0x4c, 0x6f, 0x67, 0x69, 0x6e, 0x52, 0x65, 0x73, 0x70, 0x6f, 0x6e, 0x73, 0x65, 0x12, 0x0e, 0x0a,
	0x02, 0x69, 0x64, 0x18, 0x01, 0x20, 0x01, 0x28, 0x04, 0x52, 0x02, 0x69, 0x64, 0x12, 0x21, 0x0a,
	0x0c, 0x61, 0x63, 0x63, 0x65, 0x73, 0x73, 0x5f, 0x74, 0x6f, 0x6b, 0x65, 0x6e, 0x18, 0x02, 0x20,
	0x01, 0x28, 0x09, 0x52, 0x0b, 0x61, 0x63, 0x63, 0x65, 0x73, 0x73, 0x54, 0x6f, 0x6b, 0x65, 0x6e,
	0x22, 0xa2, 0x01, 0x0a, 0x0a, 0x41, 0x63, 0x63, 0x6f, 0x75, 0x6e, 0x74, 0x44, 0x74, 0x6f, 0x12,
	0x16, 0x0a, 0x06, 0x55, 0x73, 0x65, 0x72, 0x49, 0x64, 0x18, 0x01, 0x20, 0x01, 0x28, 0x04, 0x52,
	0x06, 0x55, 0x73, 0x65, 0x72, 0x49, 0x64, 0x12, 0x1a, 0x0a, 0x08, 0x55, 0x73, 0x65, 0x72, 0x6e,
	0x61, 0x6d, 0x65, 0x18, 0x02, 0x20, 0x01, 0x28, 0x09, 0x52, 0x08, 0x55, 0x73, 0x65, 0x72, 0x6e,
	0x61, 0x6d, 0x65, 0x12, 0x1a, 0x0a, 0x08, 0x50, 0x61, 0x73, 0x73, 0x77, 0x6f, 0x72, 0x64, 0x18,
	0x03, 0x20, 0x01, 0x28, 0x09, 0x52, 0x08, 0x50, 0x61, 0x73, 0x73, 0x77, 0x6f, 0x72, 0x64, 0x12,
	0x14, 0x0a, 0x05, 0x45, 0x6d, 0x61, 0x69, 0x6c, 0x18, 0x04, 0x20, 0x01, 0x28, 0x09, 0x52, 0x05,
	0x45, 0x6d, 0x61, 0x69, 0x6c, 0x12, 0x12, 0x0a, 0x04, 0x52, 0x6f, 0x6c, 0x65, 0x18, 0x05, 0x20,
	0x01, 0x28, 0x09, 0x52, 0x04, 0x52, 0x6f, 0x6c, 0x65, 0x12, 0x1a, 0x0a, 0x08, 0x49, 0x73, 0x41,
	0x63, 0x74, 0x69, 0x76, 0x65, 0x18, 0x06, 0x20, 0x01, 0x28, 0x08, 0x52, 0x08, 0x49, 0x73, 0x41,
	0x63, 0x74, 0x69, 0x76, 0x65, 0x22, 0x10, 0x0a, 0x0e, 0x46, 0x69, 0x6e, 0x64, 0x41, 0x6c, 0x6c,
	0x52, 0x65, 0x71, 0x75, 0x65, 0x73, 0x74, 0x22, 0x3a, 0x0a, 0x0f, 0x46, 0x69, 0x6e, 0x64, 0x41,
	0x6c, 0x6c, 0x52, 0x65, 0x73, 0x70, 0x6f, 0x6e, 0x73, 0x65, 0x12, 0x27, 0x0a, 0x08, 0x61, 0x63,
	0x63, 0x6f, 0x75, 0x6e, 0x74, 0x73, 0x18, 0x01, 0x20, 0x03, 0x28, 0x0b, 0x32, 0x0b, 0x2e, 0x41,
	0x63, 0x63, 0x6f, 0x75, 0x6e, 0x74, 0x44, 0x74, 0x6f, 0x52, 0x08, 0x61, 0x63, 0x63, 0x6f, 0x75,
	0x6e, 0x74, 0x73, 0x22, 0x23, 0x0a, 0x11, 0x47, 0x65, 0x74, 0x50, 0x72, 0x6f, 0x66, 0x69, 0x6c,
	0x65, 0x52, 0x65, 0x71, 0x75, 0x65, 0x73, 0x74, 0x12, 0x0e, 0x0a, 0x02, 0x69, 0x64, 0x18, 0x01,
	0x20, 0x01, 0x28, 0x09, 0x52, 0x02, 0x69, 0x64, 0x22, 0x35, 0x0a, 0x12, 0x47, 0x65, 0x74, 0x50,
	0x72, 0x6f, 0x66, 0x69, 0x6c, 0x65, 0x52, 0x65, 0x73, 0x70, 0x6f, 0x6e, 0x73, 0x65, 0x12, 0x1f,
	0x0a, 0x06, 0x70, 0x65, 0x72, 0x73, 0x6f, 0x6e, 0x18, 0x01, 0x20, 0x01, 0x28, 0x0b, 0x32, 0x07,
	0x2e, 0x50, 0x65, 0x72, 0x73, 0x6f, 0x6e, 0x52, 0x06, 0x70, 0x65, 0x72, 0x73, 0x6f, 0x6e, 0x22,
	0x1d, 0x0a, 0x07, 0x52, 0x65, 0x71, 0x75, 0x65, 0x73, 0x74, 0x12, 0x12, 0x0a, 0x04, 0x6e, 0x61,
	0x6d, 0x65, 0x18, 0x01, 0x20, 0x01, 0x28, 0x09, 0x52, 0x04, 0x6e, 0x61, 0x6d, 0x65, 0x22, 0x26,
	0x0a, 0x08, 0x52, 0x65, 0x73, 0x70, 0x6f, 0x6e, 0x73, 0x65, 0x12, 0x1a, 0x0a, 0x08, 0x67, 0x72,
	0x65, 0x65, 0x74, 0x69, 0x6e, 0x67, 0x18, 0x02, 0x20, 0x01, 0x28, 0x09, 0x52, 0x08, 0x67, 0x72,
	0x65, 0x65, 0x74, 0x69, 0x6e, 0x67, 0x2a, 0x36, 0x0a, 0x08, 0x55, 0x73, 0x65, 0x72, 0x52, 0x6f,
	0x6c, 0x65, 0x12, 0x11, 0x0a, 0x0d, 0x41, 0x64, 0x6d, 0x69, 0x6e, 0x69, 0x73, 0x74, 0x72, 0x61,
	0x74, 0x6f, 0x72, 0x10, 0x00, 0x12, 0x0b, 0x0a, 0x07, 0x54, 0x6f, 0x75, 0x72, 0x69, 0x73, 0x74,
	0x10, 0x01, 0x12, 0x0a, 0x0a, 0x06, 0x41, 0x75, 0x74, 0x68, 0x6f, 0x72, 0x10, 0x02, 0x32, 0x69,
	0x0a, 0x0e, 0x47, 0x72, 0x65, 0x65, 0x74, 0x65, 0x72, 0x53, 0x65, 0x72, 0x76, 0x69, 0x63, 0x65,
	0x12, 0x2a, 0x0a, 0x05, 0x47, 0x72, 0x65, 0x65, 0x74, 0x12, 0x08, 0x2e, 0x52, 0x65, 0x71, 0x75,
	0x65, 0x73, 0x74, 0x1a, 0x09, 0x2e, 0x52, 0x65, 0x73, 0x70, 0x6f, 0x6e, 0x73, 0x65, 0x22, 0x0c,
	0x82, 0xd3, 0xe4, 0x93, 0x02, 0x06, 0x3a, 0x01, 0x2a, 0x22, 0x01, 0x2f, 0x12, 0x2b, 0x0a, 0x09,
	0x47, 0x72, 0x65, 0x65, 0x74, 0x54, 0x65, 0x73, 0x74, 0x12, 0x08, 0x2e, 0x52, 0x65, 0x71, 0x75,
	0x65, 0x73, 0x74, 0x1a, 0x09, 0x2e, 0x52, 0x65, 0x73, 0x70, 0x6f, 0x6e, 0x73, 0x65, 0x22, 0x09,
	0x82, 0xd3, 0xe4, 0x93, 0x02, 0x03, 0x12, 0x01, 0x2f, 0x32, 0x8f, 0x02, 0x0a, 0x12, 0x53, 0x74,
	0x61, 0x6b, 0x65, 0x68, 0x6f, 0x6c, 0x64, 0x65, 0x72, 0x53, 0x65, 0x72, 0x76, 0x69, 0x63, 0x65,
	0x12, 0x58, 0x0a, 0x0f, 0x52, 0x65, 0x67, 0x69, 0x73, 0x74, 0x72, 0x61, 0x74, 0x69, 0x6f, 0x6e,
	0x52, 0x70, 0x63, 0x12, 0x14, 0x2e, 0x52, 0x65, 0x67, 0x69, 0x73, 0x74, 0x72, 0x61, 0x74, 0x69,
	0x6f, 0x6e, 0x52, 0x65, 0x71, 0x75, 0x65, 0x73, 0x74, 0x1a, 0x15, 0x2e, 0x52, 0x65, 0x67, 0x69,
	0x73, 0x74, 0x72, 0x61, 0x74, 0x69, 0x6f, 0x6e, 0x52, 0x65, 0x73, 0x70, 0x6f, 0x6e, 0x73, 0x65,
	0x22, 0x18, 0x82, 0xd3, 0xe4, 0x93, 0x02, 0x12, 0x3a, 0x01, 0x2a, 0x22, 0x0d, 0x2f, 0x72, 0x65,
	0x67, 0x69, 0x73, 0x74, 0x72, 0x61, 0x74, 0x69, 0x6f, 0x6e, 0x12, 0x4b, 0x0a, 0x0f, 0x46, 0x69,
	0x6e, 0x64, 0x41, 0x6c, 0x6c, 0x55, 0x73, 0x65, 0x72, 0x73, 0x52, 0x70, 0x63, 0x12, 0x0f, 0x2e,
	0x46, 0x69, 0x6e, 0x64, 0x41, 0x6c, 0x6c, 0x52, 0x65, 0x71, 0x75, 0x65, 0x73, 0x74, 0x1a, 0x10,
	0x2e, 0x46, 0x69, 0x6e, 0x64, 0x41, 0x6c, 0x6c, 0x52, 0x65, 0x73, 0x70, 0x6f, 0x6e, 0x73, 0x65,
	0x22, 0x15, 0x82, 0xd3, 0xe4, 0x93, 0x02, 0x0f, 0x12, 0x0d, 0x2f, 0x66, 0x69, 0x6e, 0x64, 0x41,
	0x6c, 0x6c, 0x55, 0x73, 0x65, 0x72, 0x73, 0x12, 0x52, 0x0a, 0x0d, 0x47, 0x65, 0x74, 0x50, 0x72,
	0x6f, 0x66, 0x69, 0x6c, 0x65, 0x52, 0x70, 0x63, 0x12, 0x12, 0x2e, 0x47, 0x65, 0x74, 0x50, 0x72,
	0x6f, 0x66, 0x69, 0x6c, 0x65, 0x52, 0x65, 0x71, 0x75, 0x65, 0x73, 0x74, 0x1a, 0x13, 0x2e, 0x47,
	0x65, 0x74, 0x50, 0x72, 0x6f, 0x66, 0x69, 0x6c, 0x65, 0x52, 0x65, 0x73, 0x70, 0x6f, 0x6e, 0x73,
	0x65, 0x22, 0x18, 0x82, 0xd3, 0xe4, 0x93, 0x02, 0x12, 0x12, 0x10, 0x2f, 0x67, 0x65, 0x74, 0x50,
	0x72, 0x6f, 0x66, 0x69, 0x6c, 0x65, 0x2f, 0x7b, 0x69, 0x64, 0x7d, 0x32, 0x4b, 0x0a, 0x0b, 0x41,
	0x75, 0x74, 0x68, 0x53, 0x65, 0x72, 0x76, 0x69, 0x63, 0x65, 0x12, 0x3c, 0x0a, 0x08, 0x4c, 0x6f,
	0x67, 0x69, 0x6e, 0x52, 0x70, 0x63, 0x12, 0x0d, 0x2e, 0x4c, 0x6f, 0x67, 0x69, 0x6e, 0x52, 0x65,
	0x71, 0x75, 0x65, 0x73, 0x74, 0x1a, 0x0e, 0x2e, 0x4c, 0x6f, 0x67, 0x69, 0x6e, 0x52, 0x65, 0x73,
	0x70, 0x6f, 0x6e, 0x73, 0x65, 0x22, 0x11, 0x82, 0xd3, 0xe4, 0x93, 0x02, 0x0b, 0x3a, 0x01, 0x2a,
	0x22, 0x06, 0x2f, 0x6c, 0x6f, 0x67, 0x69, 0x6e, 0x42, 0x0f, 0x5a, 0x0d, 0x70, 0x72, 0x6f, 0x74,
	0x6f, 0x2f, 0x67, 0x72, 0x65, 0x65, 0x74, 0x65, 0x72, 0x62, 0x06, 0x70, 0x72, 0x6f, 0x74, 0x6f,
	0x33,
}

var (
	file_greeter_greeter_service_proto_rawDescOnce sync.Once
	file_greeter_greeter_service_proto_rawDescData = file_greeter_greeter_service_proto_rawDesc
)

func file_greeter_greeter_service_proto_rawDescGZIP() []byte {
	file_greeter_greeter_service_proto_rawDescOnce.Do(func() {
		file_greeter_greeter_service_proto_rawDescData = protoimpl.X.CompressGZIP(file_greeter_greeter_service_proto_rawDescData)
	})
	return file_greeter_greeter_service_proto_rawDescData
}

var file_greeter_greeter_service_proto_enumTypes = make([]protoimpl.EnumInfo, 1)
var file_greeter_greeter_service_proto_msgTypes = make([]protoimpl.MessageInfo, 13)
var file_greeter_greeter_service_proto_goTypes = []interface{}{
	(UserRole)(0),                // 0: UserRole
	(*User)(nil),                 // 1: User
	(*Person)(nil),               // 2: Person
	(*RegistrationRequest)(nil),  // 3: RegistrationRequest
	(*RegistrationResponse)(nil), // 4: RegistrationResponse
	(*LoginRequest)(nil),         // 5: LoginRequest
	(*LoginResponse)(nil),        // 6: LoginResponse
	(*AccountDto)(nil),           // 7: AccountDto
	(*FindAllRequest)(nil),       // 8: FindAllRequest
	(*FindAllResponse)(nil),      // 9: FindAllResponse
	(*GetProfileRequest)(nil),    // 10: GetProfileRequest
	(*GetProfileResponse)(nil),   // 11: GetProfileResponse
	(*Request)(nil),              // 12: Request
	(*Response)(nil),             // 13: Response
}
var file_greeter_greeter_service_proto_depIdxs = []int32{
	0,  // 0: User.Role:type_name -> UserRole
	7,  // 1: FindAllResponse.accounts:type_name -> AccountDto
	2,  // 2: GetProfileResponse.person:type_name -> Person
	12, // 3: GreeterService.Greet:input_type -> Request
	12, // 4: GreeterService.GreetTest:input_type -> Request
	3,  // 5: StakeholderService.RegistrationRpc:input_type -> RegistrationRequest
	8,  // 6: StakeholderService.FindAllUsersRpc:input_type -> FindAllRequest
	10, // 7: StakeholderService.GetProfileRpc:input_type -> GetProfileRequest
	5,  // 8: AuthService.LoginRpc:input_type -> LoginRequest
	13, // 9: GreeterService.Greet:output_type -> Response
	13, // 10: GreeterService.GreetTest:output_type -> Response
	4,  // 11: StakeholderService.RegistrationRpc:output_type -> RegistrationResponse
	9,  // 12: StakeholderService.FindAllUsersRpc:output_type -> FindAllResponse
	11, // 13: StakeholderService.GetProfileRpc:output_type -> GetProfileResponse
	6,  // 14: AuthService.LoginRpc:output_type -> LoginResponse
	9,  // [9:15] is the sub-list for method output_type
	3,  // [3:9] is the sub-list for method input_type
	3,  // [3:3] is the sub-list for extension type_name
	3,  // [3:3] is the sub-list for extension extendee
	0,  // [0:3] is the sub-list for field type_name
}

func init() { file_greeter_greeter_service_proto_init() }
func file_greeter_greeter_service_proto_init() {
	if File_greeter_greeter_service_proto != nil {
		return
	}
	if !protoimpl.UnsafeEnabled {
		file_greeter_greeter_service_proto_msgTypes[0].Exporter = func(v interface{}, i int) interface{} {
			switch v := v.(*User); i {
			case 0:
				return &v.state
			case 1:
				return &v.sizeCache
			case 2:
				return &v.unknownFields
			default:
				return nil
			}
		}
		file_greeter_greeter_service_proto_msgTypes[1].Exporter = func(v interface{}, i int) interface{} {
			switch v := v.(*Person); i {
			case 0:
				return &v.state
			case 1:
				return &v.sizeCache
			case 2:
				return &v.unknownFields
			default:
				return nil
			}
		}
		file_greeter_greeter_service_proto_msgTypes[2].Exporter = func(v interface{}, i int) interface{} {
			switch v := v.(*RegistrationRequest); i {
			case 0:
				return &v.state
			case 1:
				return &v.sizeCache
			case 2:
				return &v.unknownFields
			default:
				return nil
			}
		}
		file_greeter_greeter_service_proto_msgTypes[3].Exporter = func(v interface{}, i int) interface{} {
			switch v := v.(*RegistrationResponse); i {
			case 0:
				return &v.state
			case 1:
				return &v.sizeCache
			case 2:
				return &v.unknownFields
			default:
				return nil
			}
		}
		file_greeter_greeter_service_proto_msgTypes[4].Exporter = func(v interface{}, i int) interface{} {
			switch v := v.(*LoginRequest); i {
			case 0:
				return &v.state
			case 1:
				return &v.sizeCache
			case 2:
				return &v.unknownFields
			default:
				return nil
			}
		}
		file_greeter_greeter_service_proto_msgTypes[5].Exporter = func(v interface{}, i int) interface{} {
			switch v := v.(*LoginResponse); i {
			case 0:
				return &v.state
			case 1:
				return &v.sizeCache
			case 2:
				return &v.unknownFields
			default:
				return nil
			}
		}
		file_greeter_greeter_service_proto_msgTypes[6].Exporter = func(v interface{}, i int) interface{} {
			switch v := v.(*AccountDto); i {
			case 0:
				return &v.state
			case 1:
				return &v.sizeCache
			case 2:
				return &v.unknownFields
			default:
				return nil
			}
		}
		file_greeter_greeter_service_proto_msgTypes[7].Exporter = func(v interface{}, i int) interface{} {
			switch v := v.(*FindAllRequest); i {
			case 0:
				return &v.state
			case 1:
				return &v.sizeCache
			case 2:
				return &v.unknownFields
			default:
				return nil
			}
		}
		file_greeter_greeter_service_proto_msgTypes[8].Exporter = func(v interface{}, i int) interface{} {
			switch v := v.(*FindAllResponse); i {
			case 0:
				return &v.state
			case 1:
				return &v.sizeCache
			case 2:
				return &v.unknownFields
			default:
				return nil
			}
		}
		file_greeter_greeter_service_proto_msgTypes[9].Exporter = func(v interface{}, i int) interface{} {
			switch v := v.(*GetProfileRequest); i {
			case 0:
				return &v.state
			case 1:
				return &v.sizeCache
			case 2:
				return &v.unknownFields
			default:
				return nil
			}
		}
		file_greeter_greeter_service_proto_msgTypes[10].Exporter = func(v interface{}, i int) interface{} {
			switch v := v.(*GetProfileResponse); i {
			case 0:
				return &v.state
			case 1:
				return &v.sizeCache
			case 2:
				return &v.unknownFields
			default:
				return nil
			}
		}
		file_greeter_greeter_service_proto_msgTypes[11].Exporter = func(v interface{}, i int) interface{} {
			switch v := v.(*Request); i {
			case 0:
				return &v.state
			case 1:
				return &v.sizeCache
			case 2:
				return &v.unknownFields
			default:
				return nil
			}
		}
		file_greeter_greeter_service_proto_msgTypes[12].Exporter = func(v interface{}, i int) interface{} {
			switch v := v.(*Response); i {
			case 0:
				return &v.state
			case 1:
				return &v.sizeCache
			case 2:
				return &v.unknownFields
			default:
				return nil
			}
		}
	}
	type x struct{}
	out := protoimpl.TypeBuilder{
		File: protoimpl.DescBuilder{
			GoPackagePath: reflect.TypeOf(x{}).PkgPath(),
			RawDescriptor: file_greeter_greeter_service_proto_rawDesc,
			NumEnums:      1,
			NumMessages:   13,
			NumExtensions: 0,
			NumServices:   3,
		},
		GoTypes:           file_greeter_greeter_service_proto_goTypes,
		DependencyIndexes: file_greeter_greeter_service_proto_depIdxs,
		EnumInfos:         file_greeter_greeter_service_proto_enumTypes,
		MessageInfos:      file_greeter_greeter_service_proto_msgTypes,
	}.Build()
	File_greeter_greeter_service_proto = out.File
	file_greeter_greeter_service_proto_rawDesc = nil
	file_greeter_greeter_service_proto_goTypes = nil
	file_greeter_greeter_service_proto_depIdxs = nil
}
