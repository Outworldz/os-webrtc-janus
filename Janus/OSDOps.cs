// Copyright 2024 Robert Adams (misterblue@misterblue.com)
//
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using OpenMetaverse.StructuredData;

namespace WebRtcVoice
{
    public static class OSDOps
    {
        // These are helper functions to extract the "result" value from a OSDMap,
        //     which is the standard way Janus returns results.
        // This definition adds these functions to the OSDMap class so, to use:
        //   OSDMap something;
        //   if (something.TryGetString("key", out string outValue))
        //      ... do stuff with "outValue" ...

        // Get string value indexed by "pKey" from OSDMap. Return null if not found
        public static bool TryGetString(this OSDMap pMap, string pKey, out string pResult)
        {
            if (pMap is not null && pMap.TryGetValue(pKey, out OSD tmp))
            {
                pResult = tmp.AsString(); // OSD's AsString does proper conversions
                return true;
            }
            pResult = null;
            return false;
        }

        // Get OSDMap indexed by "pKey" from OSDMap. Return null if not found
        public static bool TryGetOSDMap(this OSDMap pMap, string pKey, out OSDMap pResult)
        {
            if (pMap is not null && pMap.TryGetValue(pKey, out OSD tmp))
            {
                pResult = tmp as OSDMap; // sets 'null' if not an OSDMap
                return pResult is not null;
            }
            pResult = null;
            return false;
        }

        // Get OSD indexed by "pKey" from OSDMap. Return null if not found
        public static bool TryGetValue(this OSDMap pMap, string pKey, out OSD pResult)
        {
            if (pMap is not null && pMap.TryGetValue(pKey, out OSD tmp))
            {
                pResult = tmp;
                return true;
            }
            pResult = null;
            return false;
        }
    }
}

