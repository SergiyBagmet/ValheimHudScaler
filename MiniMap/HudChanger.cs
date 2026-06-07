using UnityEngine;

namespace ValheimHudScaler.Minimap
{
    public class MinimapHudChanger : MonoBehaviour
    {
        private const string MinimapObjectName = "MiniMap";
        private const string MiniHudObjectName = "HUD";
        private const string MinimapFrameObjectName = "MinimapFrame";

        private global::Minimap minimap;
        private RectTransform minimapTransform;
        private RectTransform miniHudTransform;
        private GameObject minimapFrameObject;

        private float minimapScale = 1f;
        private float miniHudScale = 1f;
        private FrameShape frameShape = FrameShape.Circle;

        public void Init()
        {
            FindHudObjects();
            ApplyAll();
        }

        public void Shutdown()
        {
            // Здесь можно вернуть оригинальные параметры, если потребуется.
        }

        public void SetMinimapInstance(global::Minimap minimap)
        {
            this.minimap = minimap;
            FindHudObjects();
            ApplyAll();
        }

        private FrameShape previousFrameShape = FrameShape.Square;

        public void SetMinimapScale(float scale)
        {
            minimapScale = Mathf.Max(0.1f, scale);
            ApplyMinimapScale();
        }

        public void ChangeMinimapScale(float delta)
        {
            SetMinimapScale(minimapScale + delta);
        }

        public void SetMiniHudScale(float scale)
        {
            miniHudScale = Mathf.Max(0.1f, scale);
            ApplyMiniHudScale();
        }

        public void ChangeMiniHudScale(float delta)
        {
            SetMiniHudScale(miniHudScale + delta);
        }

        public void SetFrameShape(FrameShape shape)
        {
            frameShape = shape;
            ApplyFrameShape();
        }

        public void ToggleCircleFrame()
        {
            if (frameShape == FrameShape.Circle)
            {
                SetFrameShape(previousFrameShape);
            }
            else
            {
                previousFrameShape = frameShape;
                SetFrameShape(FrameShape.Circle);
            }
        }

        private void FindHudObjects()
        {
            if (minimap != null)
            {
                minimapTransform = minimap.m_mapImageSmall?.rectTransform;
                miniHudTransform = minimap.m_smallRoot?.GetComponent<RectTransform>() ?? minimap.m_mapSmall?.GetComponent<RectTransform>();
                minimapFrameObject = minimap.m_mapSmall ?? minimap.m_smallRoot ?? minimap.m_largeRoot;
                return;
            }

            minimapTransform = FindRectTransform(MinimapObjectName);
            miniHudTransform = FindRectTransform(MiniHudObjectName);
            minimapFrameObject = GameObject.Find(MinimapFrameObjectName);
        }

        private RectTransform FindRectTransform(string name)
        {
            var go = GameObject.Find(name);
            return go ? go.GetComponent<RectTransform>() : null;
        }

        private void ApplyAll()
        {
            ApplyMinimapScale();
            ApplyMiniHudScale();
            ApplyFrameShape();
        }

        private void ApplyMinimapScale()
        {
            if (minimapTransform != null)
            {
                minimapTransform.localScale = Vector3.one * minimapScale;
            }
        }

        private void ApplyMiniHudScale()
        {
            if (miniHudTransform != null)
            {
                miniHudTransform.localScale = Vector3.one * miniHudScale;
            }
        }

        private void ApplyFrameShape()
        {
            if (minimapFrameObject == null)
            {
                return;
            }

            var rect = minimapFrameObject.GetComponent<RectTransform>();
            switch (frameShape)
            {
                case FrameShape.Circle:
                    // TODO: подставить конкретную реализацию рамки для круглого вида
                    break;
                case FrameShape.Square:
                    if (rect != null)
                    {
                        rect.sizeDelta = new Vector2(300f, 300f);
                    }
                    break;
                case FrameShape.Rounded:
                    if (rect != null)
                    {
                        rect.sizeDelta = new Vector2(320f, 320f);
                    }
                    break;
            }
        }

        public enum FrameShape
        {
            Circle,
            Square,
            Rounded
        }
    }
}
