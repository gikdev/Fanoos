<script lang="ts">
  import type { VariantProps } from "tailwind-variants";
  import { btn } from "./btn";
  import type { HTMLButtonAttributes } from "svelte/elements";

  type Props = VariantProps<typeof btn> & HTMLButtonAttributes;

  let { children, isIcon = false, class: className = "", ...rest }: Props = $props();
</script>

<button type="button" class={btn({ isIcon, className: className?.toString() })} {...rest}>
  {@render children?.()}
</button>
