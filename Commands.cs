//using Newtonsoft.Json.Linq;
using OBSWebsocketDotNet;
using OBSWebsocketDotNet.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class Commands
    {
        protected OBSWebsocket _obs;

        public Commands()
        {
            _obs = new OBSWebsocket();

            _obs.Connected += onConnect;
            _obs.Disconnected += onDisconnect;

            _obs.SceneChanged += onSceneChange;
            _obs.SceneCollectionChanged += onSceneColChange;
            _obs.ProfileChanged += onProfileChange;
            _obs.TransitionChanged += onTransitionChange;
            _obs.TransitionDurationChanged += onTransitionDurationChange;

            _obs.StreamingStateChanged += onStreamingStateChange;
            _obs.RecordingStateChanged += onRecordingStateChange;

            _obs.StreamStatus += onStreamData;
        }

        private void onConnect(object sender, EventArgs e)
        {
                var streamStatus = _obs.GetStreamingStatus();
                if (streamStatus.IsStreaming)
                    onStreamingStateChange(_obs, OutputState.Started);
                else
                    onStreamingStateChange(_obs, OutputState.Stopped);

                if (streamStatus.IsRecording)
                    onRecordingStateChange(_obs, OutputState.Started);
                else
                    onRecordingStateChange(_obs, OutputState.Stopped);

            _obs.Connect("ws://127.0.0.1:4444", "");
            
        }

        private void onDisconnect(object sender, EventArgs e)
        {
            
        }

        private void onSceneChange(OBSWebsocket sender, string newSceneName)
        {
            
        }

        private void onSceneColChange(object sender, EventArgs e)
        {
            
        }

        private void onProfileChange(object sender, EventArgs e)
        {
            
        }

        private void onTransitionChange(OBSWebsocket sender, string newTransitionName)
        {
            
        }

        private void onTransitionDurationChange(OBSWebsocket sender, int newDuration)
        {
            
        }

        private void onStreamingStateChange(OBSWebsocket sender, OutputState newState)
        {
            string state = "";
            switch (newState)
            {
                case OutputState.Starting:
                    state = "Stream starting...";
                    break;

                case OutputState.Started:
                    state = "Stop streaming";
                    
                    break;

                case OutputState.Stopping:
                    state = "Stream stopping...";
                    break;

                case OutputState.Stopped:
                    state = "Start streaming";
                    
                    break;

                default:
                    state = "State unknown";
                    break;
            }

            
        }

        private void onRecordingStateChange(OBSWebsocket sender, OutputState newState)
        {
            string state = "";
            switch (newState)
            {
                case OutputState.Starting:
                    state = "Recording starting...";
                    break;

                case OutputState.Started:
                    state = "Stop recording";
                    break;

                case OutputState.Stopping:
                    state = "Recording stopping...";
                    break;

                case OutputState.Stopped:
                    state = "Start recording";
                    break;

                default:
                    state = "State unknown";
                    break;
            }

            
        }

        private void onStreamData(OBSWebsocket sender, StreamStatus data)
        {
            /*
            BeginInvoke((MethodInvoker)delegate
            {
                txtStreamTime.Text = data.TotalStreamTime.ToString() + " sec";
                txtKbitsSec.Text = data.KbitsPerSec.ToString() + " kbit/s";
                txtBytesSec.Text = data.BytesPerSec.ToString() + " bytes/s";
                txtFramerate.Text = data.FPS.ToString() + " FPS";
                txtStrain.Text = (data.Strain * 100).ToString() + " %";
                txtDroppedFrames.Text = data.DroppedFrames.ToString();
                txtTotalFrames.Text = data.TotalFrames.ToString();
            });
            */
        }

    }
}
