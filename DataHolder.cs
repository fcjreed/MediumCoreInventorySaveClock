using System.Collections.Generic;

namespace MediumCoreInventorySaveClock {

    public class DataHolder {
        public Dictionary<int, int> inventoryState = new Dictionary<int, int>();
		public Dictionary<int, int> equipState = new Dictionary<int, int>();
		public Dictionary<int, int> miscState = new Dictionary<int, int>();
		public Dictionary<int, int> equipDye = new Dictionary<int, int>();
		public Dictionary<int, int> miscDye = new Dictionary<int, int>();
    }


}