<script lang="ts">
  import type { HTMLSelectAttributes } from "svelte/elements";

  type Props = HTMLSelectAttributes;
  let { children,class: className = "", ...props }: Props = $props();
</script>

<select dir="auto" class={className} {...props}>
  {@render children?.()}
</select>
