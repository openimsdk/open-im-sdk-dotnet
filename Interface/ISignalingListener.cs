namespace open_im_sdk.listener
{
    public interface ISignalingListener
    {
        void OnReceiveNewInvitation(string receiveNewInvitationCallback);
        void OnInviteeAccepted(string inviteeAcceptedCallback);
        void OnInviteeAcceptedByOtherDevice(string inviteeAcceptedCallback);
        void OnInviteeRejected(string inviteeRejectedCallback);
        void OnInviteeRejectedByOtherDevice(string inviteeRejectedCallback);
        void OnInvitationCancelled(string invitationCancelledCallback);
        void OnInvitationTimeout(string invitationTimeoutCallback);
        void OnHangUp(string hangUpCallback);
        void OnRoomParticipantConnected(string onRoomParticipantConnectedCallback);
        void OnRoomParticipantDisconnected(string onRoomParticipantDisconnectedCallback);
    }
}